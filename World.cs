using System;

namespace WestWorld
{
    public class World
    {
        //
        public World(int width, int height)
        {
            Roxels = new Roxel[width, height];
        }

        //
        public void WorldInit()
        {

            for (int x = 0; x < Roxels.GetLength(0); x++)
            {
                for (int y = 0; y < Roxels.GetLength(1); y++)
                {

                    //Roxels[x, y].BgCol = ConsoleColor.DarkBlue;
                    //Roxels[x, y].FgCol = ConsoleColor.DarkGreen;
                    //Roxels[x, y].Char = '▒';
                }
            }
        }

        //
        public Roxel[,] Roxels { get; set; }
    }
}
