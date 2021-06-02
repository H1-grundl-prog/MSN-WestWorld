// Gunslinger base class

namespace WestWorld
{
    public class GunSlinger
    {
        public GunSlinger()
        {
            Name      = "Gunslinger";
            IsAlive   = true;
            Precision = 0.5f;
            Speed     = 0.5f;
            HitPoints = 100;
            Score     = 0;
        }

        public GunSlinger(string name, bool isAlive, float precision, float speed, int hitPoints, int score)
        {
            Name      = name;
            IsAlive   = isAlive;
            Precision = precision;
            Speed     = speed;
            HitPoints = hitPoints;
            Score     = score;
        }

        // Properties
        public string Name { get; set; }
        public bool IsAlive { get; set; }
        public float Precision { get; set; }
        public float Speed { get; set; }
        public int HitPoints { get; set; }
        public int Score { get; set; }
    }
}
