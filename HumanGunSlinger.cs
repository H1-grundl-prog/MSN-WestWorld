// Human controlled player

namespace WestWorld
{
    public class HumanGunSlinger : GunSlinger
    {
        public HumanGunSlinger() : base() { }

        public HumanGunSlinger(string name, string description, bool isAlive, int precision, int speed, int hitPoints, int score) : base(name, description, isAlive, precision, speed, hitPoints, score) { }



    }
}
