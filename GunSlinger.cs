// Gunslinger base class

using System;

namespace WestWorld
{
    public class GunSlinger
    {
        public GunSlinger()
        {
            Name = "";
            Description = "";
            IsAlive = false;
            Precision = 0;
            Speed = 0;
            HitPoints = 0;
            Score = 0;
        }

        public GunSlinger(string name, string description, bool isAlive, int precision, int speed, int hitPoints, int score)
        {
            Name = name;
            Description = description;
            IsAlive = isAlive;
            Precision = precision;
            MaxPrecision = precision;
            Speed = speed;
            MaxSpeed = speed;
            HitPoints = hitPoints;
            MaxHitPoints = hitPoints;
            Score = score;
        }

        // Methods
        public virtual void Shoot(GunSlinger enemy)
        {
            if (enemy == null) { return; }
            
            // Calculate damage given to opponent
            if(IsAlive == true)
            {
                // Update precision and speed as a function of hitpoints
                Precision = MaxPrecision * (MaxHitPoints - (MaxHitPoints - HitPoints)) / MaxHitPoints;
                Speed = MaxSpeed * (MaxHitPoints - (MaxHitPoints - HitPoints)) / MaxHitPoints;

                var rand = new Random();

                // Did we hit the enemy?
                bool didPlayerHitEnemy = Precision >= rand.Next(MaxPrecision) ? true : false;

                // If yes, do damage
                if (didPlayerHitEnemy == true)
                {
                    enemy.HitPoints -= Precision/MaxPrecision;
                }
            }
            
        }


        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAlive { get; set; }
        public int Precision { get; set; }
        public int MaxPrecision { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public int HitPoints { get; set; }
        public int MaxHitPoints { get; set; }
        public int Score { get; set; }
    }
}
