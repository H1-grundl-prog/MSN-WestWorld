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

            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 0));
            BadGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 2000, 0));

            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 0));
            GoodGunSlingers.Add(new GunSlinger("Player 5", "Average gunslinger", true, true, 10, 100, 0));
        }
        #endregion
    }
}
