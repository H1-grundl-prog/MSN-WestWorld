// AI controlled player. This is basically Yuel Brynner.

namespace WestWorld
{
    public class RobotGunSlinger : GunSlinger
    {
        public RobotGunSlinger() : base() { }

        public RobotGunSlinger(string name, bool isAlive, float precision, float speed, int hitPoints, int score) : base(name, isAlive, precision, speed, hitPoints, score) { }
    }
}
