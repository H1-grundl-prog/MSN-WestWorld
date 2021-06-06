// Main game controller class
using System;
using System.Threading;

namespace WestWorld
{
    public class Game
    {
        #region fields
        int GameStartTime;
        public World World;
        public ViewPort ViewPort;
        public ConsoleKeyInfo keyPressed;
        #endregion

        #region properties
        public int NumRounds { get; set; }
        public int CurrentRound { get; set; }
        public bool IsGameRunning { get; set; }
        public Controls Controls { get; set; }
        public CountDownTimer CountDown { get; set; }
        #endregion

        #region constructors
        public Game(World world, ViewPort viewPort)
        {
            World = world;
            ViewPort = viewPort;

            CountDown = new CountDownTimer(3000);
        }
        #endregion

        #region methods
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
            Controls = ViewPort.WelcomeScreen(World);

            Controls.ConvertConsoleKeyToInt();

            Console.WriteLine(Controls.inputInt1);
            Console.WriteLine(Controls.inputInt2);

            if (Controls.inputInt1 >= 1 && Controls.inputInt1 <= World.GoodGunSlingers.Count)
            {
                World.humanPlayer = World.GoodGunSlingers[Controls.inputInt1 - 1];
            }
            else
            {
                World.robotPlayer = World.GoodGunSlingers[0];
            }

            if (Controls.inputInt2 >= 1 && Controls.inputInt2 <= World.BadGunSlingers.Count)
            {
                World.robotPlayer = World.BadGunSlingers[Controls.inputInt2 - 1];
            }
            else
            {
                World.robotPlayer = World.BadGunSlingers[0];
            }

            if(World.humanPlayer == null || World.robotPlayer == null ) { return; }

            while (IsGameRunning == true)
            {

                UpdateUserInput();

                // Robot player AI
                //Shoot(World.humanPlayer, World.robotPlayer);
                Shoot(World.robotPlayer, World.humanPlayer);

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
            bool didAttackerHitAttacked = attacker.HitChance >= rand.Next(attacker.MaxHitChance + 1);

            // If yes, kill opponent
            if (didAttackerHitAttacked == true)
            {
                attacked.IsAlive = false;
            }
        }

        public void UpdatePlayerLogic(GunSlinger g)
        {
               
        }

        public void UpdateUserInput()
        {
            if (Console.KeyAvailable == true)
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
        }


        public void GameShutdown()
        {

        }
        #endregion
    }
}
