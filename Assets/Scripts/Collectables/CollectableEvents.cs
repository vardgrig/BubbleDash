using System;

namespace Collectables
{
    public static class CollectableEvents
    {
        public static event Action Collect;

        public static void OnCollect()
        {
            Collect?.Invoke();
        }
    }
}