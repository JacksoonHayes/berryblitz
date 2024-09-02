DROP DATABASE IF EXISTS dat602;
CREATE DATABASE dat602;
USE dat602;

DROP USER if exists 'sapo'@'localhost';
CREATE USER 'sapo'@'localhost' IDENTIFIED BY '53211';
GRANT ALL ON dat602.* TO 'sapo'@'localhost';

DELIMITER //
DROP PROCEDURE IF EXISTS MakeTables//
CREATE PROCEDURE MakeTables()
BEGIN
	SET FOREIGN_KEY_CHECKS = 0;
    
	DROP TABLE IF EXISTS player;
    CREATE TABLE player (
        player_id INT PRIMARY KEY AUTO_INCREMENT,
        username VARCHAR(50) NOT NULL,
        `password` VARCHAR(50) NOT NULL DEFAULT '123',
        email VARCHAR(100) NOT NULL DEFAULT 'test@email.com', -- Will be unique on release
        score INT DEFAULT 0,
        total_berries_collected INT DEFAULT 0,
        games_played INT DEFAULT 0,
        games_won INT DEFAULT 0,
        login_attempts INT DEFAULT 0,
        is_admin BOOLEAN DEFAULT false
    );

    DROP TABLE IF EXISTS game;
    CREATE TABLE game (
        game_id INT PRIMARY KEY AUTO_INCREMENT,
        player_id INT, 
        hometile_id INT, 
        `status` VARCHAR(25) DEFAULT 'active',
        start_time TIME NOT NULL,
        current_turn VARCHAR(75),
        session_id INT,
        FOREIGN KEY (session_id) REFERENCES chat_session(session_id)
    );

    DROP TABLE IF EXISTS game_player;
    CREATE TABLE game_player (
        game_id INT,
        player_id INT,
        PRIMARY KEY (game_id, player_id),
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES player(player_id) ON DELETE CASCADE
    );

    DROP TABLE IF EXISTS tile;
    CREATE TABLE tile (
        tile_id INT PRIMARY KEY AUTO_INCREMENT,
        game_id INT NOT NULL,
        player_id INT,
        item_id INT,
        FOREIGN KEY (game_id) REFERENCES game(game_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES player(player_id) ON DELETE SET NULL,
        FOREIGN KEY (item_id) REFERENCES item(item_id) ON DELETE SET NULL
    );

    DROP TABLE IF EXISTS item;
    CREATE TABLE item (
        item_id INT PRIMARY KEY AUTO_INCREMENT,
        `type` VARCHAR(100) NOT NULL,
        points INT NOT NULL
    );

    DROP TABLE IF EXISTS inventory;
    CREATE TABLE inventory (
        inventory_id INT PRIMARY KEY AUTO_INCREMENT,
        player_id INT UNIQUE NOT NULL,
        quantity INT DEFAULT 0,
        FOREIGN KEY (player_id) REFERENCES player(player_id) ON DELETE CASCADE
    );

    DROP TABLE IF EXISTS item_inventory;
    CREATE TABLE item_inventory (
        item_id INT,
        inventory_id INT,
        PRIMARY KEY (item_id, inventory_id),
        FOREIGN KEY (item_id) REFERENCES item(item_id) ON DELETE CASCADE,
        FOREIGN KEY (inventory_id) REFERENCES inventory(inventory_id) ON DELETE CASCADE
    );

    DROP TABLE IF EXISTS chat_session;
    CREATE TABLE chat_session (
        session_id INT PRIMARY KEY AUTO_INCREMENT,
        game_id INT UNIQUE,
        start_time TIME NOT NULL,
        end_time TIME
    );

    DROP TABLE IF EXISTS chat;
    CREATE TABLE chat (
        chat_id INT PRIMARY KEY AUTO_INCREMENT,
        session_id INT NOT NULL,
        player_id INT NOT NULL,
        time_sent TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
        message VARCHAR(100) NOT NULL,
        FOREIGN KEY (session_id) REFERENCES chat_session(session_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES player(player_id) ON DELETE CASCADE
    );
    SET FOREIGN_KEY_CHECKS = 1;
END//
DELIMITER ;
	
call MakeTables();

-- Insert Players
INSERT INTO Player (username, `password`, email, score, total_berries_collected, games_played, games_won, login_attempts, is_admin)
VALUES ('John', 'password1', 'player1@example.com', 100, 20, 5, 2, 1, false);

INSERT INTO Player (username, `password`, email, score, total_berries_collected, games_played, games_won, login_attempts, is_admin)
VALUES ('Jim', 'password2', 'player2@example.com', 150, 30, 10, 5, 0, true);

-- Insert Items
INSERT INTO Item (type, points)
VALUES ('Berry', 50), ('Poisonous Berry', -50);

-- Insert Inventory for Players
INSERT INTO Inventory (player_id, quantity)
VALUES (1, 5), (2, 10);

-- Link Items to Inventory
INSERT INTO Item_Inventory (item_id, inventory_id)
VALUES (1, 1), (2, 2);

-- Insert Chat Session
INSERT INTO chat_session (start_time, end_time)
VALUES ('12:00:00', NULL);

-- Insert Game
INSERT INTO Game (player_id, hometile_id, status, start_time, current_turn, session_id)
VALUES (1, 1, 'active', '12:00:00', 'Player1 Turn', 1);

-- Link Players to Game
INSERT INTO Game_Player (game_id, player_id)
VALUES (1, 1), (1, 2);

-- Insert Tiles
INSERT INTO Tile (game_id, player_id, item_id)
VALUES (1, 1, 1), (1, 2, 2);

-- Insert Chat Messages
INSERT INTO Chat (session_id, player_id, message)
VALUES (1, 1, 'Hello, ready to play?'), (1, 2, 'Yes, let\'s start!');


-- Verify Players
SELECT * FROM Player;

-- Verify Items
SELECT * FROM Item;

-- Verify Inventory and Linked Items
SELECT i.inventory_id, p.username, ii.item_id, it.type
FROM Inventory i
JOIN Player p ON i.player_id = p.player_id
JOIN Item_Inventory ii ON i.inventory_id = ii.inventory_id
JOIN Item it ON ii.item_id = it.item_id;

-- Verify Game and Linked Players
SELECT g.game_id, g.status, g.current_turn, p.username
FROM Game g
JOIN Game_Player gp ON g.game_id = gp.game_id
JOIN Player p ON gp.player_id = p.player_id;

-- Verify Tiles and Occupied Players
SELECT t.tile_id, t.game_id, p.username, i.type
FROM Tile t
JOIN Player p ON t.player_id = p.player_id
JOIN Item i ON t.item_id = i.item_id;

-- Verify Game and Linked Players
SELECT g.game_id, g.status, g.current_turn, p.username
FROM Game g
JOIN Game_Player gp ON g.game_id = gp.game_id
JOIN Player p ON gp.player_id = p.player_id;

-- Verify Tiles and Occupied Players
SELECT t.tile_id, t.game_id, p.username, i.type
FROM Tile t
JOIN Player p ON t.player_id = p.player_id
JOIN Item i ON t.item_id = i.item_id;

-- Verify Chat Messages
SELECT c.chat_id, cs.session_id, p.username, c.message
FROM Chat c
JOIN chat_session cs ON c.session_id = cs.session_id
JOIN Player p ON c.player_id = p.player_id;

-- Update a Player's Score
UPDATE Player SET score = 200 WHERE player_id = 1;

-- Verify the update
SELECT username, score FROM Player WHERE player_id = 1;

-- Delete a Player and check if related data is deleted
DELETE FROM Player WHERE player_id = 2;

-- Check if the related data in other tables is affected
SELECT * FROM Game_Player;
SELECT * FROM Tile;
SELECT * FROM Chat;


-- Procedures for data access
DROP PROCEDURE IF EXISTS Login;
DELIMITER //
CREATE PROCEDURE `Login`(IN pUserName VARCHAR(50), IN pPassword VARCHAR(50))
BEGIN
    DECLARE userCount INT;
    DECLARE message VARCHAR(255);

    SELECT count(*) INTO userCount
    FROM player
    WHERE username = pUserName AND `password` = pPassword;

    IF userCount > 0 THEN
        SET message = 'Login successful';
    ELSE
        SET message = 'Invalid username or password';
    END IF;

    SELECT message;
END //
DELIMITER ;

SELECT username, login_attempts
FROM player;

DROP PROCEDURE IF EXISTS AddUserName;
DELIMITER //
CREATE PROCEDURE AddUserName(IN pUserName VARCHAR(50), IN pPassword VARCHAR(50))
BEGIN
  IF EXISTS (SELECT * 
     FROM player
     WHERE username = pUserName) THEN
  BEGIN
     SELECT 'Account with that name already exists!' AS MESSAGE;
  END;
  ELSE 
     INSERT INTO player(username,`password`,score)
     VALUE (pUserName, pPassword, 1000);
     SELECT 'Added new user' AS MESSAGE;
  END IF;
  
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS CreateGame;
DELIMITER //
CREATE PROCEDURE CreateGame(IN pStartTime TIME)
BEGIN
    DECLARE message VARCHAR(255);
    
    INSERT INTO game (start_time) VALUES (pStartTime);

    SET message = 'Game created successfully!';
    SELECT message AS Message;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS GetAllPlayers;
DELIMITER //
CREATE PROCEDURE GetAllPlayers()
BEGIN
    SELECT username, score FROM player;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS GetAllGames;
DELIMITER //
CREATE PROCEDURE GetAllGames()
BEGIN
    SELECT game_id FROM game;
END //
DELIMITER ;

/*
DROP PROCEDURE IF EXISTS DeletePlayer;
DELIMITER //
CREATE PROCEDURE DeletePlayer(IN pPlayerId INT)
BEGIN
    DELETE FROM player WHERE player_id = pPlayerId;

    SELECT 'Player deleted successfully' AS Message;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS DeleteGame;
DELIMITER //
CREATE PROCEDURE DeleteGame(IN pGameId INT)
BEGIN
    DELETE FROM game WHERE game_id = pGameId;

    SELECT 'Game deleted successfully' AS Message;
END //
DELIMITER ;
*/
