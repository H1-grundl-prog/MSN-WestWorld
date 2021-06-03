// Main game controller class
using System;

namespace WestWorld
{
    public class Game
    {
        // Constructors
        public Game(World world, ViewPort viewPort)
        {
            World = world;
            ViewPort = viewPort;

            GameInit();
        }

        // Methods
        public void GameInit()
        {
            World.WorldInit();

            ViewPort.InitScreen();

            ViewPort.ActiveScreen = Screens.WelcomeScreen;

            GameLoop();
        }

        public void GameLoop()
        {
            // Welcome menu
            PlayerInput = ViewPort.ShowWelcomeScreen(World);

            if (PlayerInput.keyInt >= 1 && PlayerInput.keyInt <= World.BadGunSlingers.Count)
            {
                World.robotPlayer = World.BadGunSlingers[PlayerInput.keyInt - 1];

                Console.WriteLine(World.robotPlayer.Name);
            }

            while (true)
            {
                switch (PlayerInput.keyPress.Key)
                {
                    case ConsoleKey.Escape: // Quit
                        GameShutdown();
                        break;

                    case ConsoleKey.Spacebar: // Shoot
                        World.humanPlayer.Shoot(World.robotPlayer);
                        break;

                }

                // Robot player AI
                World.robotPlayer.Shoot(World.humanPlayer);

            }

            GameShutdown();
        }

        public void GameShutdown()
        {

        }

        // Properties
        public int NumRounds { get; set; }
        public int CurrentRound { get; set; }
        public PlayerInput PlayerInput { get; set; }

        // Fields
        public World World;
        public ViewPort ViewPort;
    }
}
