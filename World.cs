using System.Collections.Generic;

namespace WestWorld
{
    public class World
    {
        #region fields
        public GunSlinger humanPlayer;
        public GunSlinger robotPlayer;
        #endregion

        #region properties
        public List<GunSlinger> BadGunSlingers { get; set; }
        public List<GunSlinger> GoodGunSlingers { get; set; }
        #endregion

        #region constructors
        public World()
        {
            BadGunSlingers = new List<GunSlinger>();
            GoodGunSlingers = new List<GunSlinger>();
        }
        #endregion

        #region methods
        public void Init()
        {

            BadGunSlingers.Add(new GunSlinger("Player 1", "Average gunslinger", true, false, 5,  1000));
            BadGunSlingers.Add(new GunSlinger("Player 2", "Average gunslinger", true, false, 15,  200));
            BadGunSlingers.Add(new GunSlinger("Player 3", "Average gunslinger", true, false, 25,  300));
            BadGunSlingers.Add(new GunSlinger("Player 4", "Average gunslinger", true, false, 35,  400));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, false, 45,  500));

            GoodGunSlingers.Add(new GunSlinger("Player 6", "Average gunslinger", true, false, 55, 600));
            GoodGunSlingers.Add(new GunSlinger("Player 7", "Average gunslinger", true, false, 65, 700));
            GoodGunSlingers.Add(new GunSlinger("Player 8", "Average gunslinger", true, false, 75, 800));
            GoodGunSlingers.Add(new GunSlinger("Player 9", "Average gunslinger", true, false, 85, 900));
            GoodGunSlingers.Add(new GunSlinger("Player 10", "Average gunslinger", true, false, 95, 1000));
        }
        #endregion
    }
}
