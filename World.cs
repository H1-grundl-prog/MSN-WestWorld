using System.Collections.Generic;

namespace WestWorld
{
    public class World
    {
        //
        public World()
        {
            GunSlingers = new List<RobotGunSlinger>();
        }

        //
        public void WorldInit()
        {

            GunSlingers.Add(new RobotGunSlinger("Player 1", "Slow shooter with good aim", true, 10, 90, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 2", "Random drunk old guy", true, 20, 80, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 3", "Average gunslinger", true, 30, 70, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 4", "Quick shooter with bad aim", true, 40, 60, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("The Gunslinger", "Yuel Brynner", true, 100, 100, 100, 0));
        }

        public HumanGunSlinger humanPlayer { get; set; }
        public RobotGunSlinger robotPlayer { get; set; }

        public List<RobotGunSlinger> GunSlingers { get; set; }
    }
}
