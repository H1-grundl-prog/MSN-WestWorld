using System;
using System.Collections.Generic;
using System.Text;

namespace WestWorld
{
    public class CountDownTimer
    {
        #region properties
        public int NumTicks { get; set; }
        public int TicksLeft { get; set; }
        public int StartTicks { get; set; }
        public bool IsRunning { get; set; }
        #endregion

        #region constructors
        public CountDownTimer(int numTicks)
        {
            NumTicks = numTicks;
            TicksLeft = numTicks;
            StartTicks = 0;
            IsRunning = false;
        }
        #endregion

        #region methods
        public void Start()
        {
            if(IsRunning == false)
            {
                IsRunning = true;
                StartTicks = Environment.TickCount;
                TicksLeft = NumTicks;
            }
        }

        public void Stop()
        {
            if (IsRunning == true)
            {
                IsRunning = false;
                StartTicks = Environment.TickCount;
                TicksLeft = NumTicks;
            }
        }

        public void Update()
        {
            if (IsRunning == false)
                return;
                
            if(TicksLeft > 0)
            {
                TicksLeft = Environment.TickCount - StartTicks;
            }
            else
            {
                IsRunning = false;
            }   
        }

        public override string ToString()
        {
            return $"NumTicks: {NumTicks}, TicksLeft: {TicksLeft}, StartTicks: {StartTicks}, IsRunning: {IsRunning}";
        }
        #endregion
    }
}
