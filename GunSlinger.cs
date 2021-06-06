// Gunslinger base class

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
        public int HitChance { get; set; }
        public int MaxHitChance { get; set; }
        public int ReactionTicks { get; set; }
        public int MaxReactionTime { get; set; }
        public int Score { get; set; }
        //public Revolver revolver { get; set; }
        #endregion

        #region constructors
        public GunSlinger() { }

        public GunSlinger(string name, string description, bool isAlive, bool canShoot, int hitChance, int reactionTime, int score)
        {
            Name = name;
            Description = description;
            IsAlive = isAlive;
            CanShoot = canShoot;
            HitChance = hitChance;
            MaxHitChance = hitChance;
            ReactionTicks = reactionTime;
            MaxReactionTime = reactionTime;
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
