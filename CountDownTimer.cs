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
        public Func<bool> RunAfterCountDown { get; set; }
        #endregion

        #region constructors
        public CountDownTimer(int numTicks)
        {
            NumTicks = numTicks;
            TicksLeft = numTicks;
            StartTicks = 0;
            IsRunning = false;
        }

        public CountDownTimer(int numTicks, Func<bool> runAfterCountDown)
        {
            NumTicks = numTicks;
            TicksLeft = numTicks;
            StartTicks = 0;
            IsRunning = false;
            RunAfterCountDown = runAfterCountDown;
        }
        #endregion

        #region methods
        public void Start()
        {
            if(IsRunning == false)
            {
                IsRunning = true;
                TicksLeft = NumTicks;
                StartTicks = Environment.TickCount;
            }
        }

        public void Reset()
        {
            if (IsRunning == true)
            {
                IsRunning = false;
                TicksLeft = NumTicks;
                StartTicks = 0;
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
                Reset();
                RunAfterCountDown?.Invoke();
            }   
        }

        public override string ToString()
        {
            return $"NumTicks: {NumTicks}, TicksLeft: {TicksLeft}, StartTicks: {StartTicks}, IsRunning: {IsRunning}";
        }
        #endregion
    }
}
