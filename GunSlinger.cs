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
        public bool HasDrawnGun { get; set; }
        public int HitChance { get; set; }
        public int ReactionTime { get; set; }
        public int Score { get; set; }
        //public Revolver revolver { get; set; }
        public CountDownTimer ReactionTimer;
        #endregion

        #region constructors
        public GunSlinger() { }

        public GunSlinger(string name, string description, bool isAlive, bool canShoot, int hitChance, int reactionTime)
        {
            Name = name;
            Description = description;
            IsAlive = isAlive;
            HasDrawnGun = canShoot;
            HitChance = hitChance;
            ReactionTime = reactionTime;

            Score = 0;

            ReactionTimer = new CountDownTimer(ReactionTime, DrawGun);
        }
        #endregion

        #region methods
        public bool ReachForGun()
        {
            if (!IsAlive || ReactionTimer.IsRunning || HasDrawnGun)
                return false;

            // Okay, we can draw our gun
            Console.WriteLine($"{Name} is reaching for his gun!");
            HasDrawnGun = false;
            ReactionTimer.Start();
            return true;

        }
        public bool DrawGun()
        {
            //Console.WriteLine("FireGun called!");
            HasDrawnGun = true;
            return true;
        }
        public override string ToString()
        {
            return "";
        }
        #endregion
    }
}
