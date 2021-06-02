// Main game controller class

using System.Threading;

namespace WestWorld
{
    public class Game
    {
        //
        public Game(World world, ViewPort viewPort)
        {
            World = world;
            ViewPort = viewPort;

            GameInit();
        }

        //
        public void GameInit()
        {
            IsGameRunning = true;

            World.WorldInit();

            ViewPort.InitScreen();

            GameLoop();
        }

        public void GameLoop()
        {
            ViewPort.ShowWelcomeScreen(World.GunSlingers);


            while (IsGameRunning)
            {
                
            }

            GameShutdown();
        }

        public void GameShutdown()
        {

        }

        //
        bool IsGameRunning;

        //
        public World World;
        public ViewPort ViewPort;
    }
}
