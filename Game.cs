// Main game controller class
using System;
using System.Threading;

namespace WestWorld
{
    public class Game
    {
        // Constructors
        public Game(World world, ViewPort viewPort)
        {
            World = world;
            ViewPort = viewPort;
        }

        // Methods
        public void GameInit()
        {
            World.Init();
            ViewPort.Init();

            IsGameRunning = true;
            GameStartTime = Environment.TickCount;
            GameLoop();
        }

        public void GameLoop()
        {
            // Welcome menu
            // Select player and opponent.
            PlayerInput = ViewPort.ShowWelcomeScreen(World);

            PlayerInput.ConvertConsoleKeyToInt();

            Console.WriteLine(PlayerInput.inputInt1);
            Console.WriteLine(PlayerInput.inputInt2);

            if (PlayerInput.inputInt1 >= 1 && PlayerInput.inputInt1 <= World.GoodGunSlingers.Count)
            {
                World.humanPlayer = World.GoodGunSlingers[PlayerInput.inputInt1 - 1];
            }
            else
            {
                World.robotPlayer = World.GoodGunSlingers[0];
            }

            if (PlayerInput.inputInt2 >= 1 && PlayerInput.inputInt2 <= World.BadGunSlingers.Count)
            {
                World.robotPlayer = World.BadGunSlingers[PlayerInput.inputInt2 - 1];
            }
            else
            {
                World.robotPlayer = World.BadGunSlingers[0];
            }

            if(World.humanPlayer == null || World.robotPlayer == null ) { return; }

            while (IsGameRunning == true)
            {
                
                if ( Console.KeyAvailable == true)
                {
                    keyPressed = Console.ReadKey(false);
                }

                switch (keyPressed.Key)
                {
                    case ConsoleKey.Escape: // Quit
                        IsGameRunning = false;
                        break;

                    case ConsoleKey.Spacebar: // Shoot
                        Shoot(World.humanPlayer, World.robotPlayer);
                        break;

                }
                

                //Console.WriteLine(Console.KeyAvailable);

                // Robot player AI
                //Shoot(World.humanPlayer, World.robotPlayer);
                Shoot(World.robotPlayer, World.humanPlayer);

                Console.WriteLine(World.humanPlayer.HitPoints);
                Console.WriteLine(World.robotPlayer.HitPoints);
                Console.WriteLine();

                UpdatePlayerLogic(World.humanPlayer);
                UpdatePlayerLogic(World.robotPlayer);

                keyPressed = new ConsoleKeyInfo();

                Console.WriteLine(Environment.TickCount - GameStartTime);

                Thread.Sleep(10);

            }

            GameShutdown();
        }

        public void Shoot(GunSlinger attacker, GunSlinger attacked)
        {
            if (attacker.IsAlive == false || attacked.IsAlive == false) { return; }

            if (attacker.CanShoot == false ) { return; }

            var rand = new Random();

            // Did we hit the enemy?
            bool didAttackerHitAttacked = attacker.Precision >= rand.Next(attacker.MaxPrecision + 1) ? true : false;

            // If yes, do damage
            if (didAttackerHitAttacked == true)
            {
                attacked.HitPoints -= 1; // * (Precision / MaxPrecision);
            }

            attacker.CanShoot = false;
            attacker.LastShootTime = Environment.TickCount;
        }

        public void UpdatePlayerLogic(GunSlinger g)
        {
            // Update precision and speed as a function of hitpoints
            g.Precision = g.MaxPrecision * (g.HitPoints / g.MaxHitPoints);
            g.ReactionTime = g.MaxReactionTime * (g.HitPoints / g.MaxHitPoints);

            if (g.HitPoints <= 0) { g.IsAlive = false; }

            int timeSinceLastShot = Environment.TickCount - g.LastShootTime;

            if (timeSinceLastShot >= g.ReactionTime) { g.CanShoot = true; }
        }

        public void GameShutdown()
        {

        }

        // Properties
        public ConsoleKeyInfo keyPressed;

        int GameStartTime;

        public int NumRounds { get; set; }
        public int CurrentRound { get; set; }
        public bool IsGameRunning { get; set; }
        public PlayerInput PlayerInput { get; set; }

        // Fields
        public World World;
        public ViewPort ViewPort;
    }
}
