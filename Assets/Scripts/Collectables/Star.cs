using Interfaces;
using UnityEngine;

namespace Collectables
{
    public class Star : MonoBehaviour, ICollectable
    {
        [SerializeField] private string soundName;

        public void OnCollect()
        {
            CollectableEvents.OnCollect();
        }
    }
}