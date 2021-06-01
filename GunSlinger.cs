using System;
using System.Collections.Generic;
using System.Text;

// Gunslinger base class

namespace WestWorld
{
    public class GunSlinger
    {
        public GunSlinger() { }

        // Properties
        public float Precision { get; set; }
        public float Speed { get; set; }
        public float HitPoints { get; set; }
        public Vec2 Position { get; set; }
        public Vec2 GunAngle { get; set; }
    }
}
