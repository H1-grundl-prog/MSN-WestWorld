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

            //
            Controls = ViewPort.ChooseEnemyScreen(World);

            Controls.Update();

            if (Controls.inputInt >= 1 && Controls.inputInt <= World.BadGunSlingers.Count)
            {
                World.robotPlayer = World.BadGunSlingers[Controls.inputInt - 1];
            }
            else
            {
                var rand = new Random();

                World.robotPlayer = World.BadGunSlingers[rand.Next(World.BadGunSlingers.Count)];
            }

            Controls = ViewPort.ChoosePlayerScreen(World);

            Controls.Update();

            if (Controls.inputInt >= 1 && Controls.inputInt <= World.GoodGunSlingers.Count)
            {
                World.humanPlayer = World.GoodGunSlingers[Controls.inputInt - 1];
            }
            else
            {
                var rand = new Random();

                World.humanPlayer = World.GoodGunSlingers[rand.Next(World.GoodGunSlingers.Count)];
            }

            if (World.humanPlayer == null || World.robotPlayer == null ) { GameLoop(); }

            while (IsGameRunning == true)
            {
                //Console.Clear();
                //Console.SetCursorPosition(1, 10);
                
                UpdateUserInput();

                // Robot player AI
                World.robotPlayer.ReachForGun();

                World.humanPlayer.ReactionTimer.Update();
                World.robotPlayer.ReactionTimer.Update();

                Shoot(World.robotPlayer, World.humanPlayer);
                Shoot(World.humanPlayer, World.robotPlayer);

                // Reset keyPressed (read-only)
                keyPressed = new ConsoleKeyInfo();

                //Thread.Sleep(10);

            }

            GameShutdown();
        }

        public void Shoot(GunSlinger attacker, GunSlinger attacked)
        {
            if (!attacker.IsAlive || !attacked.IsAlive) { return; }

            if (!attacker.HasDrawnGun) { return; }

            Console.WriteLine($"{attacker.Name} fires revolver at {attacked.Name}!");

            var rand = new Random();

            // Did we hit the enemy?
            bool didAttackerHitAttacked = attacker.HitChance >= rand.Next(101);

            // If yes, kill opponent
            if (didAttackerHitAttacked)
            {
                Console.WriteLine($"{attacker.Name} hits {attacked.Name}!");
                attacked.IsAlive = false;
            }
            else
            {
                Console.WriteLine($"{attacker.Name} misses {attacked.Name}!");
            }

            attacker.HasDrawnGun = false;
        }

        public void UpdatePlayerLogic(GunSlinger g)
        {
               
        }

        public void UpdateUserInput()
        {
            if (Console.KeyAvailable)
            {
                keyPressed = Console.ReadKey(false);
            }

            switch (keyPressed.Key)
            {
                case ConsoleKey.Escape: // Quit
                    IsGameRunning = false;
                    break;

                case ConsoleKey.Spacebar: // Shoot
                    World.humanPlayer.ReachForGun();
                    break;

            }
        }

        public void GameShutdown()
        {

        }
        #endregion
    }
}
