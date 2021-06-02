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
            while (true)
            {
                switch(ViewPort.ActiveScreen)
                {
                    case Screens.WelcomeScreen:

                        playerInput = ViewPort.ShowWelcomeScreen(World.GunSlingers);

                        if (playerInput.keyInt >= 1 && playerInput.keyInt <= World.GunSlingers.Count)
                        {
                            World.robotPlayer = World.GunSlingers[playerInput.keyInt - 1];

                            Console.WriteLine(World.robotPlayer.Name);

                            ViewPort.ActiveScreen = Screens.GameScreen;
                        }

                        break;

                    case Screens.GameScreen:

                        playerInput = ViewPort.ShowGameScreen();

                        switch (playerInput.keyPress.Key)
                        {
                            case ConsoleKey.Escape: // Quit
                                GameShutdown();
                                break;

                            case ConsoleKey.Spacebar: // Shoot
                                break;

                        }

                        break;
                }

                // Robot player AI
                World.robotPlayer.Shoot();

            }

            GameShutdown();
        }

        public void GameShutdown()
        {

        }

        // Properties
        public int NumRounds { get; set; }
        public int CurrenRound { get; set; }
        public PlayerInput playerInput { get; set; }

        // Fields
        public World World;
        public ViewPort ViewPort;
    }
}
