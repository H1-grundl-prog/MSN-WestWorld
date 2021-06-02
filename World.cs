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

            GunSlingers.Add(new RobotGunSlinger("Player 1", true, 0.1f, 1.0f, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 2", true, 0.2f, 0.9f, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 3", true, 0.2f, 0.9f, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 4", true, 0.2f, 0.9f, 100, 0));
            GunSlingers.Add(new RobotGunSlinger("Player 5", true, 1.0f, 1.0f, 100, 0));
        }

        public HumanGunSlinger humanPlayer;
        public RobotGunSlinger robotPlayer;
        
        public List<RobotGunSlinger> GunSlingers;
    }
}
