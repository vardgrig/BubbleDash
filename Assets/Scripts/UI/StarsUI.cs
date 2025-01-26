using System;
using UnityEngine;
using TMPro;

namespace UI
{
    public class StarsUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI starsText;

        private void OnEnable()
        {
            UIEvents.StarUpdate += OnStarUpdated;
        }

        private void OnDisable()
        {
            UIEvents.StarUpdate -= OnStarUpdated;
        }

        private void OnStarUpdated(int starsCount, int finalStars)
        {
            if (starsCount == finalStars)
            {
                starsText.text = "Finish";
                return;
            }
            starsText.text = starsCount + "/" + finalStars;
        }
    }
}