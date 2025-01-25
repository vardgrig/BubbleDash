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
        public static event Action<float> Burst;
        public static event Action<float, float, float> Slowdown;

        public static void OnKill()
        {
            Kill?.Invoke();
        }

        public static void OnTimerChange(float seconds)
        {
            TimerChange?.Invoke(seconds);
        }

        public static void OnExtraDash()
        {
            ExtraDash?.Invoke();
        }

        public static void OnFreezeTimer(float seconds)
        {
            FreezeTimer?.Invoke(seconds);
        }

        public static void OnExplode(float range, Vector3 pos)
        {
            Explode?.Invoke(range, pos);
        }

        public static void OnInvert(float seconds)
        {
            Invert?.Invoke(seconds);
        }

        public static void OnBurst(float range)
        {
            Burst?.Invoke(range);
        }

        public static void OnSlowdown(float duration, float speedMultiplier, float distanceMultiplier)
        {
            Slowdown?.Invoke(duration, speedMultiplier, distanceMultiplier);
        }
    }
}