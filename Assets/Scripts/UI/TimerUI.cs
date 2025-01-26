using System.Collections;
using Helpers;
using TMPro;
using UnityEngine;
using DG.Tweening;

namespace UI
{
    public class TimerUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text timerText;
        
        private CharacterController _characterController;

        private void OnEnable()
        {
            UIEvents.TimerUpdate += ChangeTimer;
        }

        private void OnDisable()
        {
            UIEvents.TimerUpdate -= ChangeTimer;
        }

        private void ChangeTimer(int seconds)
        {
            var sizeBefore = timerText.fontSize;
            var sizeAfter = timerText.fontSize + 15;
            timerText.text = TimeConverter.ToFormatMinSec(seconds);
            if (seconds < 10)
            {
                timerText.color = Color.red;
            }
            StartCoroutine(AnimateFontSize(sizeBefore, sizeAfter, 0.25f));
        }
        
        private IEnumerator AnimateFontSize(float sizeBefore, float sizeAfter, float duration)
        {
            var elapsedTime = 0f;
            
            while (elapsedTime < duration)
            {
                timerText.fontSize = Mathf.Lerp(sizeBefore, sizeAfter, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            timerText.fontSize = sizeAfter;

            elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                timerText.fontSize = Mathf.Lerp(sizeAfter, sizeBefore, elapsedTime / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            timerText.fontSize = sizeBefore;
        }
        
    }
}