# 🍓 BerryBlitz

BerryBlitz is a multiplayer, turn-based 2D game where players compete by collecting berries on a tiled map. Players gain points by collecting berries and lose points by stepping on thorns. The game ends when the timer runs out or a player collects enough berries to win. It features a Windows Forms GUI and uses a MySQL database for data persistence, including user management and score tracking.

The application includes integrated chat for player interaction, admin panels for managing users and scores, and a full backend powered by ADO.NET.

## Features

- Turn-based movement across a 2D tile grid.
- Scoring system with berries (+) and thorns (−).
- Real-time chat system between players.
- Admin interface for managing players and scores.
- MySQL database for persistence of users, scores, and game state.

## Technologies Used

- C# (.NET Framework 4.7.2)
- Windows Forms
- MySQL
- ADO.NET (MySQL Connector)
- TCP Chat Server

## Project Structure

```
DAT602_Project/
├── AddUserForm.cs              # Form for user registration
├── AdminForm.cs                # Admin dashboard for player management
├── GameForm.cs                 # Main game UI
├── Game.cs                     # Core gameplay logic
├── ChatServer.cs               # Handles in-game messaging
├── DataAccess.cs               # Database connection logic
├── UserDAO.cs                  # User authentication and lookup
├── TokenDAO.cs                 # Turn and token management
├── App.config                  # Configuration file with DB connection string
├── DAT602_Project.sln          # Visual Studio solution file
```

## Setup Instructions

1. **Clone the Repository**
   ```bash
   git clone https://github.com/JacksoonHayes/berryblitz
   ```

2. **Set Up the MySQL Database**
   - Open the file: `DAT602 Documentation/DAT602 Project.sql`
   - Run it on your MySQL server to create the necessary tables and data.

3. **Configure App Settings**
   - In `App.config`, replace the connection string with your MySQL server details.

4. **Build and Run**
   - Open the solution file `DAT602_Project.sln` in Visual Studio.
   - Set `DAT602_Project` as the startup project.
   - Press `F5` to build and run.

## License

This project is licensed under the MIT License. See the [LICENSE](./LICENSE) file for details.

## Author

Developed by Jackson Hayes.
