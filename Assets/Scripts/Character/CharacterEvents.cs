using System;

namespace Character
{
    public static class CharacterEvents
    {
        public static event Action<bool> Dash;

        public static void OnDash(bool isDashing)
        {
            Dash?.Invoke(isDashing);
        }
    }
}