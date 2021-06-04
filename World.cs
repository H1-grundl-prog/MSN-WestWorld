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
        public void Init()
        {

            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 100, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 100, 0));

            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 100, 0));
        }

        public GunSlinger humanPlayer;
        public GunSlinger robotPlayer;

        public List<GunSlinger> BadGunSlingers { get; set; }
        public List<GunSlinger> GoodGunSlingers { get; set; }
    }
}
