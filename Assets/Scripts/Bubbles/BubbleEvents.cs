using System;
using UnityEngine;

namespace Bubbles
{
    public static class BubbleEvents
    {
        public static event Action<float> TimerChange;
        public static event Action Kill;
        public static event Action ExtraDash;
        public static event Action<float> FreezeTimer;
        public static event Action<float, Vector3> Explode;
        public static event Action<float> Invert;
        
        //TODO: Create all the events
        public static void OnKill()
        {
            Kill?.Invoke();
        }

        public static void OnTimerChange(float obj)
        {
            TimerChange?.Invoke(obj);
        }

        public static void OnExtraDash()
        {
            ExtraDash?.Invoke();
        }

        public static void OnFreezeTimer(float obj)
        {
            FreezeTimer?.Invoke(obj);
        }

        public static void OnExplode(float obj, Vector3 pos)
        {
            Explode?.Invoke(obj, pos);
        }

        public static void OnInvert(float obj)
        {
            Invert?.Invoke(obj);
        }
    }
}