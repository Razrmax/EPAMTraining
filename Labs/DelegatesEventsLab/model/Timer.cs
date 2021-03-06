﻿using System;
using System.Threading;

namespace DelegatesEventsLab.model
{

    /// <summary>
    /// A publisher class which imitates a countdown (Timer). Upon the initiation of the timer raises the event, counts down every second 
    /// which subscribed to this event
    /// </summary>
    class Timer
    {
        public string Name { get; }
        public int CountdownLength { get; private set; }
        private readonly int _notificationThreshold;

        public Timer(string name, int countdownLength, int notificationThreshold)
        {
            Name = name;
            CountdownLength = countdownLength;
            _notificationThreshold = notificationThreshold;
        }

        public event EventHandler<TimerEventArgs> InitTimerEvent;
        public event EventHandler<TimerEventArgs> RunTimerEvent;
        public event EventHandler<TimerEventArgs> EndTimerEvent;
        
        /// <summary>
        /// Declare the event using event handler
        /// </summary>
        public void StartCountdown()
        {
            Console.WriteLine();
            OnInitTimerEvent(new TimerEventArgs("Initiated timer " + Name + ".\nStarted " + CountdownLength + " seconds countdown", CountdownLength));
            int waitTime = CountdownLength;
            while (waitTime > 0)
            {
                if (waitTime == _notificationThreshold)
                {
                    OnRunTimerEvent(new TimerEventArgs(Convert.ToString(waitTime--), CountdownLength));
                }
                else
                {
                    Console.WriteLine(waitTime--);
                }
                Thread.Sleep(1000);
            }
            OnEndTimerEvent(new TimerEventArgs("Countdown complete.", CountdownLength));
        }

        private void OnInitTimerEvent(TimerEventArgs e)
        {
            ProcessEvent(e, InitTimerEvent);
        }

        private void OnRunTimerEvent(TimerEventArgs e)
        {
            ProcessEvent(e, RunTimerEvent);
        }

        private void OnEndTimerEvent(TimerEventArgs e)
        {
            ProcessEvent(e, EndTimerEvent);
        }

        private void ProcessEvent(TimerEventArgs e, EventHandler<TimerEventArgs> h)
        {
            EventHandler<TimerEventArgs> handler = h;
            handler?.Invoke(this, e);
        }
        /// <summary>
        /// ToString returns the Name of the timer
        /// </summary>
        /// <returns>string representation of Name property</returns>
        public override string ToString()
        {
            return Name;
        }
    }


    class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(string message, int countdownLength)
        {
            Message = message;
            CountDownLength = countdownLength;
        }

        public string Message { get; private set; }
        public int CountDownLength { get; private set; }
    }
}
