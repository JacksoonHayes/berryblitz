DROP DATABASE IF EXISTS dat602;
CREATE DATABASE dat602;
USE dat602;

DROP USER if exists 'sapo'@'localhost';
CREATE USER 'sapo'@'localhost' IDENTIFIED BY '53211';
GRANT ALL ON dat602.* TO 'sapo'@'localhost';

DROP PROCEDURE IF EXISTS makeTables;
DELIMITER //
CREATE PROCEDURE makeTables()
BEGIN
	SET FOREIGN_KEY_CHECKS = 0;
    
	DROP TABLE IF EXISTS tblPlayer;
    CREATE TABLE tblPlayer (
        player_id INT PRIMARY KEY AUTO_INCREMENT,
        username VARCHAR(50) NOT NULL,
        `password` VARCHAR(255) NOT NULL DEFAULT '123',
        email VARCHAR(100) NOT NULL DEFAULT 'test@email.com', -- Will be unique on release
        score INT DEFAULT 0,
        total_berries_collected INT DEFAULT 0,
        games_played INT DEFAULT 0,
        games_won INT DEFAULT 0,
        login_attempts INT DEFAULT 0,
        locked_out BOOLEAN DEFAULT false,
        is_banned BOOLEAN DEFAULT false,
        is_admin BOOLEAN DEFAULT false
    );

    DROP TABLE IF EXISTS tblGame;
    CREATE TABLE tblGame (
        game_id INT PRIMARY KEY AUTO_INCREMENT,
        `status` VARCHAR(25) DEFAULT 'active',
        start_time DATETIME DEFAULT CURRENT_TIMESTAMP,
        current_turn VARCHAR(75),
        move_count INT DEFAULT 0,
        max_row INT NOT NULL DEFAULT 10,
        max_col INT NOT NULL DEFAULT 10
    );

    DROP TABLE IF EXISTS tblGamePlayer;
    CREATE TABLE tblGamePlayer (
        game_id INT,
        player_id INT,
        PRIMARY KEY (game_id, player_id),
        FOREIGN KEY (game_id) REFERENCES tblGame(game_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES tblPlayer(player_id) ON DELETE CASCADE
    );
    
    DROP TABLE IF EXISTS tblTile;
    CREATE TABLE tblTile (
        tile_id INT PRIMARY KEY AUTO_INCREMENT,
        game_id INT NOT NULL,
        player_id INT,
        item_id INT,
        `row` INT NOT NULL,
        col INT NOT NULL,
        FOREIGN KEY (game_id) REFERENCES tblGame(game_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES tblPlayer(player_id) ON DELETE SET NULL,
        FOREIGN KEY (item_id) REFERENCES tblItem(item_id) ON DELETE SET NULL
    );

    DROP TABLE IF EXISTS tblItem;
    CREATE TABLE tblItem (
        item_id INT PRIMARY KEY AUTO_INCREMENT,
        `type` VARCHAR(25) NOT NULL,
        points INT NOT NULL
    );

    DROP TABLE IF EXISTS tblInventory;
    CREATE TABLE tblInventory (
        inventory_id INT PRIMARY KEY AUTO_INCREMENT,
        player_id INT UNIQUE NOT NULL,
        quantity INT DEFAULT 0,
        FOREIGN KEY (player_id) REFERENCES tblPlayer(player_id) ON DELETE CASCADE
    );

    DROP TABLE IF EXISTS tblItemInventory;
    CREATE TABLE tblItemInventory (
        item_id INT,
        inventory_id INT,
        PRIMARY KEY (item_id, inventory_id),
        FOREIGN KEY (item_id) REFERENCES tblItem(item_id) ON DELETE CASCADE,
        FOREIGN KEY (inventory_id) REFERENCES tblInventory(inventory_id) ON DELETE CASCADE
    );
	
	DROP TABLE IF EXISTS tblChatSession;
	CREATE TABLE tblChatSession (
		session_id INT PRIMARY KEY AUTO_INCREMENT,
		game_id INT UNIQUE,
		FOREIGN KEY (game_id) REFERENCES tblGame(game_id) ON DELETE CASCADE
	);

    DROP TABLE IF EXISTS tblChat;
    CREATE TABLE tblChat (
        chat_id INT PRIMARY KEY AUTO_INCREMENT,
        session_id INT NOT NULL,
        player_id INT,
        time_sent TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
        message VARCHAR(100) NOT NULL,
        FOREIGN KEY (session_id) REFERENCES tblChatSession(session_id) ON DELETE CASCADE,
        FOREIGN KEY (player_id) REFERENCES tblPlayer(player_id) ON DELETE SET NULL
    );
    
    SET FOREIGN_KEY_CHECKS = 1;
END//
DELIMITER ;
	
call makeTables();

DELIMITER //
DROP PROCEDURE IF EXISTS insertTestData//
CREATE PROCEDURE insertTestData()
BEGIN
	SET FOREIGN_KEY_CHECKS = 0;
    
	-- Insert Players
	INSERT INTO tblPlayer (username, `password`, email, score, total_berries_collected, games_played, games_won, login_attempts, is_banned, is_admin)
	VALUES ('Admin', 'admin123', 'admin@example.com', 10000, 0, 0, 0, 0, false, true),
			('Alice', 'password3', 'player3@example.com', 200, 40, 8, 3, 1, false, false),
			('Bob', 'password4', 'player4@example.com', 80, 15, 3, 1, 2, false, false),
			('Jane', 'password5', 'player5@example.com', 250, 60, 12, 7, 0, false, false),
			('Jim', 'password2', 'player2@example.com', 150, 30, 10, 5, 0, true, false);

	-- Insert Items
	INSERT INTO tblItem (`type`, points)
	VALUES ('Berry', 25), ('Golden Berry', 50), ('Thorn', -30);

	-- Insert Inventory for Players
	INSERT INTO tblInventory (player_id, quantity)
	VALUES (3, 8), (4, 12), (5, 5);

	-- Link Items to Inventory
	INSERT INTO tblItemInventory (item_id, inventory_id)
	VALUES (1, 3), (1, 4), (1, 5);

	-- Insert Game
	INSERT INTO tblGame (`status`, start_time, current_turn)
	VALUES ('active', '2024-10-10 13:00:00', 'Player2 Turn'),
		   ('active', '2024-10-10 14:00:00', 'Player3 Turn'),
		   ('inactive', '2024-10-10 15:00:00', 'Player4 Turn'),
		   ('active', '2024-10-10 16:00:00', 'Player5 Turn');

	-- Link Players to Game
	INSERT INTO tblGamePlayer (game_id, player_id)
	VALUES (2, 2), (3, 3), (4, 4), (5, 5);

	-- Insert Tiles
	INSERT INTO tblTile (game_id, player_id, item_id, `row`, col)
	VALUES (1, 2, 1, 1, 1), (1, 3, 2, 7, 2), (1, 4, 3, 7, 9), (1, 5, 4, 8, 8);

	-- Insert Chat Messages
	INSERT INTO tblChat (session_id, player_id, message)
	VALUES (2, 2, 'Good luck!'), (2, 3, 'Let\'s do this!'), 
		   (4, 4, 'I\'m ready!'), (4, 5, 'Here we go!');
	
    SET FOREIGN_KEY_CHECKS = 1;
END//
DELIMITER ;

call insertTestData();

-- Procedures for data access object
DROP PROCEDURE IF EXISTS loginUser;
DELIMITER //
CREATE PROCEDURE loginUser(IN pUserName VARCHAR(50), IN pPassword VARCHAR(50))
BEGIN
    DECLARE message VARCHAR(255);
    DECLARE numAttempts INT DEFAULT 0;
    
    IF EXISTS ( SELECT * FROM tblPlayer WHERE username = pUserName AND (locked_out = true OR is_banned = true ))
    THEN
		SELECT 'Locked out' AS message;
	ELSE
		IF EXISTS ( SELECT * FROM tblPlayer WHERE username = pUserName AND `password` = pPassword )
		THEN
			UPDATE tblPlayer
			SET login_attempts = 0
			WHERE username = pUserName;
			SELECT 'Login Successful' as message;
		ELSE 
			-- add to login_attempts
			IF EXISTS(SELECT * FROM tblPlayer WHERE username = pUserName) 
			THEN 
				SELECT login_attempts
				INTO numAttempts
				FROM tblPlayer
				WHERE username = pUserName;            
				SET numAttempts = numAttempts + 1;
				
				IF numAttempts > 3 
				THEN 
					-- if login_attempts > 3 then set lockout to true and select message 'locked out' 
					UPDATE tblPlayer
					SET locked_out = True
					WHERE username = pUserName;
					SELECT 'Locked Out' AS message;                 
				ELSE
					-- else select message 'Bad password'
					UPDATE tblPlayer
					SET login_attempts = numAttempts
					WHERE username = pUserName;
					SELECT 'Invalid username or password' AS message;
				END IF;
			ELSE 
				SELECT 'Invalid username or password' AS message;
			END IF;
		END IF;
	END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS registerUser;
DELIMITER //
CREATE PROCEDURE registerUser(IN pUserName VARCHAR(50), IN pPassword VARCHAR(50), IN pEmail VARCHAR(100))
BEGIN
  IF EXISTS (SELECT * FROM tblPlayer WHERE username = pUserName)
  THEN
     SELECT 'Account with that name already exists!' AS MESSAGE;
  ELSE 
     INSERT INTO tblPlayer(username,`password`, email ,score)
     VALUE (pUserName, pPassword, pEmail, 0);
     SELECT 'Added new user' AS MESSAGE;
  END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS addUser;
DELIMITER //
CREATE PROCEDURE addUser(IN pUserName VARCHAR(50), IN pPassword VARCHAR(50), IN pEmail VARCHAR(100))
BEGIN
  IF EXISTS (SELECT * FROM tblPlayer WHERE username = pUsername)
  THEN
     SELECT 'Account with that name already exists!' AS MESSAGE;
  ELSE 
     INSERT INTO tblPlayer(username,`password`, email)
     VALUE (pUsername, pPassword, pEmail);
     SELECT 'Added new user' AS MESSAGE;
  END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS updatePlayerProfile;
DELIMITER //
CREATE PROCEDURE updatePlayerProfile(
    IN p_player_id INT,
    IN p_username VARCHAR(50),
    IN p_password VARCHAR(50),
    IN p_email VARCHAR(100),
    IN p_locked_out BOOLEAN,
    IN p_is_banned BOOLEAN
)
BEGIN
    UPDATE tblPlayer
    SET 
        username = p_username,
        `password` = p_password,
        email = p_email,
        locked_out = p_locked_out,
        is_banned = p_is_banned
    WHERE player_id = p_player_id;
SELECT 'Profile updated succesfully' AS Message;
END //
DELIMITER ;

DROP FUNCTION IF EXISTS getTileType;
DELIMITER //
CREATE FUNCTION getTileType()
RETURNS INT
DETERMINISTIC
BEGIN
    DECLARE rand_value FLOAT;
    DECLARE selected_item_id INT;

    -- Generate a random value between 0 and 1
    SET rand_value = RAND();

    -- Determine the item_id based on the random value
    IF rand_value < 0.3 THEN
        -- 30% chance to select item_id for Berry
        SELECT item_id INTO selected_item_id FROM tblItem WHERE `type` = 'Berry' LIMIT 1;
        RETURN selected_item_id;
	ELSEIF rand_value < 0.35 THEN
        -- 5% chance to select item_id for Golden Berry
        SELECT item_id INTO selected_item_id FROM tblItem WHERE `type` = 'Golden Berry' LIMIT 1;
        RETURN selected_item_id;
    ELSEIF rand_value < 0.55 THEN
        -- 20% chance to select item_id for Thorn
        SELECT item_id INTO selected_item_id FROM tblItem WHERE `type` = 'Thorn' LIMIT 1;
        RETURN selected_item_id;
    ELSE
        -- 45% chance to create an empty tile
        RETURN NULL;
    END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS makeBoard;
DELIMITER //
CREATE PROCEDURE makeBoard(p_max_row INT, p_max_col INT)
BEGIN
    DECLARE new_board_id INT;
    DECLARE current_row INT DEFAULT 0;
    DECLARE current_col INT DEFAULT 0;
    DECLARE random_item_id INT;

    INSERT INTO tblGame(max_row, max_col)
    VALUES (p_max_row, p_max_col);

    SET new_board_id = LAST_INSERT_ID();
    
    INSERT INTO tblChatSession(game_id) 
    VALUES (new_board_id);

    -- Loop through the rows and columns to create the board
    WHILE current_row < p_max_row DO
        WHILE current_col < p_max_col DO
            -- Select a random item_id from tblItem
            SET random_item_id = getTileType();
            -- Insert the new tile with the randomly selected item_id
            INSERT INTO tblTile(game_id, `row`, col, item_id)
            VALUE (new_board_id, current_row, current_col, random_item_id);

            -- Move to the next column
            SET current_col = current_col + 1;
        END WHILE;

        -- Move to the next row and reset the column to 0
        SET current_col = 0;
        SET current_row = current_row + 1;
    END WHILE;

    SELECT "Created a new game board" AS message;
END //
DELIMITER ;

CALL makeBoard(10, 10);

DROP PROCEDURE IF EXISTS placeItemOnTile;
DELIMITER //
CREATE PROCEDURE placeItemOnTile(
    IN p_game_id INT, 
    IN p_row INT, 
    IN p_col INT, 
    IN p_item_id INT
)
BEGIN
    -- Update the item on the specific tile
    UPDATE tblTile
    SET item_id = p_item_id
    WHERE game_id = p_game_id 
    AND `row` = p_row
    AND col = p_col;
    
    -- Check if any rows were affected to confirm success
    IF ROW_COUNT() > 0 THEN
        SELECT 'Item placed successfully' AS message;
    ELSE
        SELECT 'Tile not found or item not placed' AS message;
    END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS acquireItem;
DELIMITER //
CREATE PROCEDURE acquireItem(
    IN p_player_id INT,
    IN p_tile_id INT
)
BEGIN
    DECLARE v_item_id INT;
    DECLARE v_item_type VARCHAR(50);

    -- Retrieve the item_id from the tile
    SELECT item_id 
    INTO v_item_id
    FROM tblTile
    WHERE tile_id = p_tile_id
    LIMIT 1;

    -- Check if the tile contains an item
    IF v_item_id IS NOT NULL THEN
        SELECT `type`
        INTO v_item_type
        FROM tblItem
        WHERE item_id = v_item_id;

        -- Update the player's inventory, increase quantity by 1
        UPDATE tblInventory
        SET quantity = quantity + 1
        WHERE player_id = p_player_id;

        -- Remove the item from the tile by setting item_id to NULL
        UPDATE tblTile
        SET item_id = NULL
        WHERE tile_id = p_tile_id;

        -- Provide a success message
        SELECT ('Item added to inventory') AS message;
    ELSE
        SELECT 'No item on this tile to acquire' AS message;
    END IF;
END //
DELIMITER ;


DROP PROCEDURE IF EXISTS updatePlayerScore;
DELIMITER //
CREATE PROCEDURE updatePlayerScore(IN p_player_id INT, IN p_tile_id INT)
BEGIN
    DECLARE v_points INT DEFAULT 0;
    DECLARE v_berries_collected INT DEFAULT 0;
    DECLARE v_item_type VARCHAR(50);

    -- Retrieve the item_id from tblTile and find the corresponding points from tblItem
    SELECT tblItem.points, tblItem.`type`
    INTO v_points, v_item_type
    FROM tblTile
    JOIN tblItem ON tblTile.item_id = tblItem.item_id
    WHERE tblTile.tile_id = p_tile_id;

    -- Check if the item is a berry and increment berries collected
    IF v_item_type = 'Berry' OR v_item_type = 'Golden Berry' THEN
        SET v_berries_collected = 1;
    END IF;

    -- Update player's score and total berries collected
    UPDATE tblPlayer
    SET score = score + v_points,
        total_berries_collected = total_berries_collected + v_berries_collected
    WHERE player_id = p_player_id;
    SELECT CONCAT('Player score updated by: ', v_points) AS message;

END //
DELIMITER ;

CALL updatePlayerScore(1, 2);

DROP PROCEDURE IF EXISTS moveThorns;
DELIMITER //
CREATE PROCEDURE moveThorns(IN p_game_id INT)
BEGIN
    -- Update all tiles with item_id = 3 to either 1, 2, or NULL
    UPDATE tblTile
    SET item_id = CASE
        WHEN RAND() < 0.33 THEN 1
        WHEN RAND() < 0.66 THEN 2
        ELSE NULL
    END
    WHERE game_id = p_game_id AND item_id = 3;

    -- Randomly replace tiles with item_id 1, 2, or NULL to item_id = 3 (20% chance)
    UPDATE tblTile
    SET item_id = 3
    WHERE game_id = p_game_id
    AND (item_id IN (1, 2) OR item_id IS NULL)
    AND RAND() <= 0.20;

    -- Reset move_count to 0 for repeated execution
    UPDATE tblGame
    SET move_count = 0
    WHERE game_id = p_game_id;
    SELECT "Thorns (NPC) moved successfully" AS message;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS movePlayer;
DELIMITER //
CREATE PROCEDURE movePlayer(
    IN p_player_id INT,
    IN p_game_id INT,
    IN p_new_row INT,
    IN p_new_col INT
)
BEGIN
    DECLARE v_current_row INT;
    DECLARE v_current_col INT;
    DECLARE v_tile_id INT;
	DECLARE v_item_id INT;
    DECLARE v_occupying_player_id INT;
    DECLARE v_move_count INT;
    DECLARE v_max_row INT;
    DECLARE v_max_col INT;

    -- Get the current position (tile) of the player
    SELECT `row`, col, tile_id 
    INTO v_current_row, v_current_col, v_tile_id
    FROM tblTile
    WHERE player_id = p_player_id AND game_id = p_game_id
    LIMIT 1;

    -- Get the board size (max rows and columns) from the game
    SELECT max_row, max_col 
    INTO v_max_row, v_max_col
    FROM tblGame
    WHERE game_id = p_game_id
    LIMIT 1;

    -- Check if the new position is within the board
    IF p_new_row < 0 OR p_new_row > v_max_row OR p_new_col < 0 OR p_new_col > v_max_col THEN
        SELECT 'Error: Move is out of bounds' AS message;
    ELSE
        -- Check if the move is to an adjacent tile (allowing diagonal moves)
        IF (v_current_row = p_new_row OR v_current_row = p_new_row - 1 OR v_current_row = p_new_row + 1)
           AND (v_current_col = p_new_col OR v_current_col = p_new_col - 1 OR v_current_col = p_new_col + 1) THEN

            -- Check if the target tile is already occupied
            SELECT player_id INTO v_occupying_player_id
            FROM tblTile
            WHERE `row` = p_new_row AND col = p_new_col AND game_id = p_game_id;

            -- If the target tile is not occupied, move the player
            IF v_occupying_player_id IS NULL THEN
                UPDATE tblTile
                SET player_id = NULL
                WHERE tile_id = v_tile_id;

                -- Move player to the new tile
                UPDATE tblTile
                SET player_id = p_player_id
                WHERE `row` = p_new_row AND col = p_new_col AND game_id = p_game_id;
                SELECT CONCAT('Player moved successfully to tile: ', p_new_row, ', ', p_new_col) AS message;
                
                -- Get the item_id on the new tile
                SELECT item_id INTO v_item_id 
                FROM tblTile 
                WHERE `row` = p_new_row AND col = p_new_col AND game_id = p_game_id;
                
                -- If the tile contains an item (i.e., item_id is NOT NULL), update the score
                IF v_item_id IS NOT NULL THEN
                    CALL updatePlayerScore(p_player_id, v_tile_id);
                    UPDATE tblTile
                    SET item_id = NULL
                    WHERE tile_id = v_tile_id;
                END IF;
                
				-- Increment move_count
				UPDATE tblGame
				SET move_count = move_count + 1
				WHERE game_id = p_game_id;

				-- Check if move_count >= 5 and call moveThorns
				IF (SELECT move_count FROM tblGame WHERE game_id = p_game_id) >= 5 THEN
					CALL moveThorns(p_game_id);
				END IF;
            ELSE
                SELECT 'Error: Tile is occupied by another player' AS message;
            END IF;
        ELSE
            SELECT 'Error: The tile is not adjacent' AS message;
        END IF;
    END IF;

END //
DELIMITER ;

DROP PROCEDURE IF EXISTS getAllPlayers;
DELIMITER //
CREATE PROCEDURE getAllPlayers()
BEGIN
    SELECT player_id, username, score, email, `password`, locked_out, is_banned FROM tblPlayer;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS getAllGames;
DELIMITER //
CREATE PROCEDURE getAllGames()
BEGIN
    SELECT game_id, `status` FROM tblGame;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS deletePlayer;
DELIMITER //
CREATE PROCEDURE deletePlayer(
    IN p_player_id INT
)
BEGIN
    -- Check if the player exists
    IF EXISTS (SELECT 1 FROM tblPlayer WHERE player_id = p_player_id)
    THEN
        DELETE FROM tblPlayer WHERE player_id = p_player_id;
        SELECT 'Player deleted successfully' AS Message;
    ELSE
        SELECT 'Player does not exist' AS Message;
    END IF;
END //
DELIMITER ;

DROP PROCEDURE IF EXISTS deleteGame;
DELIMITER //
CREATE PROCEDURE deleteGame(
    IN p_game_id INT
)
BEGIN
    -- Check if the game exists
    IF EXISTS (SELECT 1 FROM tblGame WHERE game_id = p_game_id) THEN
        DELETE FROM tblGame WHERE game_id = p_game_id;
        SELECT 'Game deleted successfully' AS Message;
    ELSE
        SELECT 'Game does not exist' AS Message;
    END IF;
END //
DELIMITER ;

-- All table select statements
SELECT * FROM tblPlayer;
SELECT * FROM tblGame;
SELECT * FROM tblTile;
SELECT * FROM tblItem;
SELECT * FROM tblInventory;
SELECT * FROM tblChatSession;
SELECT * FROM tblChat;

-- Login/Registration Procedure Testing
CALL registerUser("Tim", "TimsPassword", "Tim@email.com");
CALL loginUser("Tim", "Timspasword");

-- Gameplay Procedure Testing
CALL makeBoard(10, 10);
CALL placeItemOnTile(5, 1, 1, 3);
CALL movePlayer(2, 1, 1, 2);
CALL acquireItem(4, 3);
CALL updatePlayerScore(1, 2);
CALL moveThorns(5);


-- Admin Procedure Testing
CALL getAllGames();
CALL getAllPlayers();
CALL addUser("New User", "password", "Test@Gmail.com");
CALL updatePlayerProfile(7, "Updated User", "password", "Updated@gmail.com", false, true);
CALL deletePlayer(3);
CALL deleteGame(3)