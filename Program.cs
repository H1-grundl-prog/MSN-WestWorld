/*
 * Opgave:
 * 
 * Pull the trigger game:
 * - 1 player – 1 npc
 * - Timer based
 * - You need to be faster than enemy cowboy
 * - Best out of 3 wins
 * 
 * Kommentar:
 * 
 * Reference:
 * 
 */

namespace WestWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            World world = new World();

            ViewPort viewPort = new ViewPort();

            Game gunSlingerGame = new Game(world, viewPort);

            gunSlingerGame.GameInit();
        }
    }
}
