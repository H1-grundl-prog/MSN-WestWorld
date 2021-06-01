using System;
using System.Collections.Generic;
using System.Text;

/*
 * Roxel is a contraction of Rock and Pixel, a kind of 2D Voxel.
 * It holds data about physical world appeareance, collidability, and destructability.
 * The physical game world is a 2D array of Roxels.
*/

namespace WestWorld
{
    public struct Roxel
    {
        public char Char { get; set; }
        public bool IsCollidable { get; set; }
        public bool IsDestructible { get; set; }
        public ConsoleColor BgCol { get; set; }
        public ConsoleColor FgCol { get; set; }
    }
}
