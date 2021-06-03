using System.Collections.Generic;

namespace WestWorld
{
    public class World
    {
        //
        public World()
        {
            BadGunSlingers = new List<GunSlinger>();
            GoodGunSlingers = new List<GunSlinger>();
        }

        //
        public void WorldInit()
        {

            BadGunSlingers.Add(new GunSlinger("Player 1", "Slow shooter with good aim", true, 10, 90, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 2", "Random drunk old guy", true, 20, 80, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 3", "Average gunslinger", true, 30, 70, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 4", "Quick shooter with bad aim", true, 40, 60, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Yuel Brynner", "*The* Gunslinger!", true, 100, 100, 100, 0));

            GoodGunSlingers.Add(new GunSlinger("Player 1", "Average gunslinger", true, 30, 70, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 2", "Average gunslinger", true, 30, 70, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 3", "Average gunslinger", true, 30, 70, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 4", "Average gunslinger", true, 30, 70, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, 30, 70, 100, 0));
        }

        public GunSlinger humanPlayer { get; set; }
        public GunSlinger robotPlayer { get; set; }

        public List<GunSlinger> BadGunSlingers { get; set; }
        public List<GunSlinger> GoodGunSlingers { get; set; }
    }
}
