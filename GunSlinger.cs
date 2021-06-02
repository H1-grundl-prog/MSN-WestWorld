// Gunslinger base class

namespace WestWorld
{
    public class GunSlinger
    {
        public GunSlinger()
        {
            Name = "Noname Gunslinger";
            Description = "Average";
            IsAlive = true;
            Precision = 50;
            Speed = 50;
            HitPoints = 100;
            Score = 0;
        }

        public GunSlinger(string name, string description, bool isAlive, int precision, int speed, int hitPoints, int score)
        {
            Name = name;
            Description = description;
            IsAlive = isAlive;
            Precision = precision;
            Speed = speed;
            HitPoints = hitPoints;
            Score = score;
        }

        // Properties
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAlive { get; set; }
        public int Precision { get; set; }
        public int Speed { get; set; }
        public int HitPoints { get; set; }
        public int Score { get; set; }
    }
}
