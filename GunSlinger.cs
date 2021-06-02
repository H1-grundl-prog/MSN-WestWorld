﻿// Gunslinger base class

namespace WestWorld
{
    public class GunSlinger
    {
        public GunSlinger()
        {
            IsAlive = true;
            Precision = 0.5f;
            Speed = 0.5f;
            HitPoints = 100;
            Score = 0;
        }

        // Properties
        public bool IsAlive { get; set; }
        public float Precision { get; set; }
        public float Speed { get; set; }
        public int HitPoints { get; set; }
        public int Score { get; set; }
    }
}
