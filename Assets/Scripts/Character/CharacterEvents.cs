using System;

namespace Character
{
    public static class CharacterEvents
    {
        public static event Action<bool> Dash;
        public static event Action Winnable;
        public static event Action Finish;

        public static void OnDash(bool isDashing)
        {
            Dash?.Invoke(isDashing);
        }

        public static void OnWinnable()
        {
            Winnable?.Invoke();
        }

        public static void OnFinish()
        {
            Finish?.Invoke();
        }
    }
}