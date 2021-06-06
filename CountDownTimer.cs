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
        public int StartTime { get; set; }
        public int EndTime { get; set; }
        public bool IsRunning { get; set; }
        public Func<bool> RunAfterCountDown { get; set; }
        #endregion

        #region constructors
        public CountDownTimer(int numTicks)
        {
            NumTicks = numTicks;
            TicksLeft = numTicks;
            EndTime = 0;
            StartTime = 0;
            IsRunning = false;
            RunAfterCountDown = null;
        }

        public CountDownTimer(int numTicks, Func<bool> runAfterCountDown)
        {
            NumTicks = numTicks;
            TicksLeft = numTicks;
            EndTime = 0;
            StartTime = 0;
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
                StartTime = Environment.TickCount;
                EndTime = StartTime + NumTicks; 
            }
        }

        public void Reset()
        {
            if (IsRunning == true)
            {
                IsRunning = false;
                EndTime = NumTicks;
                TicksLeft = 0;
                StartTime = 0;
            }
        }

        public void Update()
        {
            if (IsRunning == false)
                return;
                
            if(EndTime <= Environment.TickCount)
            {
                Reset();
                RunAfterCountDown?.Invoke();
            }
            else
            {
                TicksLeft = EndTime - Environment.TickCount;
            }
        }

        public int TimeLeftInSeconds()
        {
            return TicksLeft / 1000;
        }

        public override string ToString()
        {
            return $"NumTicks: {NumTicks}, TicksLeft: {TicksLeft}, StartTicks: {StartTime}, IsRunning: {IsRunning}";
        }
        #endregion
    }
}
