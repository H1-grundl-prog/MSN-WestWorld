// Main game controller class

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
            while (IsGameRunning)
            {
                ViewPort.DrawWorldToScreen(World);

                //Thread.Sleep(10);
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
