using System;
using System.Collections.Generic;
using System.Text;

// Main game controller class

namespace WestWorld
{
    public class Game
    {
        public Game() { }

        //
        public void CreateNewGame()
        {

        }

        //
        public void CreateWorld()
        {
            World = new Roxel[Constants.GAME_WORLD_WIDTH, Constants.GAME_WORLD_HEIGHT];
        }

        //
        public Roxel[,] World { get; set; }

        public ViewPort Camera { get; set; }
    }
}
