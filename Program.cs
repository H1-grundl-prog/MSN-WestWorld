using System;

/*
 * Opgave:
 * 
 * Kommentar:
 * 
 * Reference:
 * https://stackoverflow.com/questions/2754518/how-can-i-write-fast-colored-output-to-console
 * https://social.microsoft.com/Forums/security/en-SG/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize?forum=csharpgeneral
 * 
 */

namespace WestWorld
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            World world = new World(Constants.GAME_WORLD_WIDTH, Constants.GAME_WORLD_HEIGHT);
            ViewPort viewPort = new ViewPort(Constants.SCREEN_WIDTH, Constants.SCREEN_HEIGHT);
            Game gunSlingerGame = new Game(world, viewPort);
        }
    }
}
