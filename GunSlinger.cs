﻿// Gunslinger base class

using System;
using System.Collections.Generic;

namespace WestWorld
{
    public class GunSlinger
    {
        # region properties
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAlive { get; set; }
        public bool CanShoot { get; set; }
        public int Precision { get; set; }
        public int MaxPrecision { get; set; }
        public int ReactionTime { get; set; }
        public int MaxReactionTime { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Score { get; set; }
        public Revolver revolver { get; set; }
        #endregion

        #region constructors
        public GunSlinger() { }

        public GunSlinger(string name, string description, bool isAlive, bool canShoot, int precision, int reactionTime, int hitPoints, int score)
        {
            Name = name;
            Description = description;
            IsAlive = isAlive;
            CanShoot = canShoot;
            Precision = precision;
            MaxPrecision = precision;
            ReactionTime = reactionTime;
            MaxReactionTime = reactionTime;
            HitPoints = hitPoints;
            MaxHitPoints = hitPoints;
            Score = score;
        }
        #endregion

        #region methods
        public override string ToString()
        {
            return "";
        }
        #endregion
    }
}
