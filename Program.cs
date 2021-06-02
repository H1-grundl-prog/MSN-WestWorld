using System;

/*
 * Opgave:
 * 
 * Kommentar:
 * 
 * Reference:
 * https://github.com/ForeverZer0/glfw-net
 * 
 */

namespace WestWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World(Constants.GAME_WORLD_WIDTH, Constants.GAME_WORLD_HEIGHT);

            ViewPort viewPort = new ViewPort(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);

            Game gunSlingerGame = new Game(world, viewPort);
        }
    }
}
