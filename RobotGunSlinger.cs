// AI controlled player. This is basically Yuel Brynner.

namespace WestWorld
{
    public class RobotGunSlinger : GunSlinger
    {
        public RobotGunSlinger() : base() { }

        public RobotGunSlinger(string name, string description, bool isAlive, int precision, int speed, int hitPoints, int score) : base(name, description, isAlive, precision, speed, hitPoints, score) { }
    
        public void Shoot()
        {

        }
    }
}
