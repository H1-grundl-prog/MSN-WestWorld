// Human controlled player

namespace WestWorld
{
    public class HumanGunSlinger : GunSlinger
    {
        public HumanGunSlinger() : base() { }
        
        public HumanGunSlinger(string name, bool isAlive, float precision, float speed, int hitPoints, int score) : base(name, isAlive, precision, speed, hitPoints, score) { }



    }
}
