using System;
using System.Collections.Generic;
using System.Text;

namespace WestWorld
{
    public class Revolver
    {
        #region properties
        public int MaxNumBullets { get; set; }
        public int NumBullets { get; set; }
        public int ReloadTicks { get; set; } // Reload time in ticks
        public int ShootTicks { get; set; } // Time between shots in ticks

        public CountDownTimer ReloadTimer;
        public CountDownTimer ShootTimer;
        #endregion

        #region constructors
        #endregion

        #region methods
        public bool Shoot()
        {
            // 
            if (NumBullets < 1)
                return false;

            if (ShootTimer.IsRunning == true)
                return false;
            
            if (ReloadTimer.IsRunning == true)
                return false;

            // Okay, we can shoot
            NumBullets--;
            ShootTimer.Start();
            return true;
        }
        
        public bool Reload()
        {
            if (ReloadTimer.IsRunning == true)
                return false;

            if (ShootTimer.IsRunning == true)
                return false;

            // Okay, we can reload
            NumBullets = MaxNumBullets;
            return true;
        }
        #endregion
    }
}
