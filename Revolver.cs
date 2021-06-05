using System;
using System.Collections.Generic;
using System.Text;

namespace WestWorld
{
    public class Revolver
    {
        #region properties
        public string name { get; set; }
        public int MaxNumBullets { get; set; }
        public int NumBullets { get; set; }
        public int ReloadTicks { get; set; } // Reload time in ticks
        public int ShootTicks { get; set; } // Time between shots in ticks

        public CountDownTimer ReloadTimer;
        public CountDownTimer ShootTimer;
        #endregion

        #region constructors
        public Revolver()
        {
            ShootTimer = new CountDownTimer(ShootTicks);
            ReloadTimer = new CountDownTimer(ReloadTicks, FinishReload);
        }

        public Revolver(int maxNumBullets, int numBullets, int reloadTicks, int shootTicks)
        {
            MaxNumBullets = maxNumBullets;
            NumBullets = numBullets;
            ReloadTicks = reloadTicks;
            ShootTicks = shootTicks;
        }
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
        
        public bool BeginReload()
        {
            if (ReloadTimer.IsRunning == true)
                return false;

            if (ShootTimer.IsRunning == true)
                return false;

            // Okay, we can reload
            ReloadTimer.Start();
            return true;
        }

        public bool FinishReload()
        {
            NumBullets = MaxNumBullets;
            return true;
        }

        public override string ToString()
        {
            return "";
        }
        #endregion
    }
}
