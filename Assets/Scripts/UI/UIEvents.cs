using System;
using System.Collections.Generic;
using Character;

namespace UI
{
    public static class UIEvents
    {
        public static event Action<int> TimerUpdate;
        public static event Action<List<Abilities>> AbilitiesUpdate;
        public static event Action<int, int> StarUpdate;

        public static void OnTimerUpdate(int seconds)
        {
            TimerUpdate?.Invoke(seconds);
        }

        public static void OnAbilitiesUpdate(List<Abilities> abilities)
        {
            AbilitiesUpdate?.Invoke(abilities);
        }

        public static void OnStarUpdate(int currentStars, int finalStarsCount)
        {
            StarUpdate?.Invoke(currentStars, finalStarsCount);
        }
    }
}