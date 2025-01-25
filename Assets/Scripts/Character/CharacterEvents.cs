using System;

namespace Character
{
    public static class CharacterEvents
    {
        public static event Action<bool> Dash;
        public static event Action Winnable;
        public static event Action Finish;
        public static event Action Dead;
        public static event Action BubbleEnter;
        public static event Action BubbleExit;
        public static event Action Win;

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

        public static void OnDead()
        {
            Dead?.Invoke();
        }

        public static void OnBubbleEnter()
        {
            BubbleEnter?.Invoke();
        }
        
        public static void OnBubbleExit()
        {
            BubbleExit?.Invoke();
        }

        public static void OnWin()
        {
            Win?.Invoke();
        }
    }
}