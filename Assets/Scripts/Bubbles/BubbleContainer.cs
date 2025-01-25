using System;
using System.Collections.Generic;
using Character;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Bubbles
{
    public class BubbleContainer : MonoBehaviour
    {
        [SerializeField] private float switchTime = 2f;
        
        private List<GameObject> _bubbles = new();
        private bool _isInBubble;
        private float _switchTime;
        private int _activatedBubbleIndex;

        private void OnEnable()
        {
            CharacterEvents.BubbleEnter += OnBubbleEntered;
            CharacterEvents.BubbleExit += OnBubbleExit;
        }

        private void OnDisable()
        {
            CharacterEvents.BubbleEnter -= OnBubbleEntered;
            CharacterEvents.BubbleExit -= OnBubbleExit;
        }

        private void Start()
        {
            AssignChildren();
            _switchTime = switchTime;
        }

        private void Update()
        {
            if (_isInBubble)
                return;
            
            if (switchTime > 0)
            {
                switchTime -= Time.deltaTime;
            }
            else
            {
                ActivateRandomBubble(_bubbles.Count);
                switchTime = _switchTime;
            }
        }

        private void AssignChildren()
        {
            var bubblesCount = transform.childCount;
            for (var i = 0; i < bubblesCount; i++)
            {
                var child = transform.GetChild(i).gameObject;
                _bubbles.Add(child);
                child.SetActive(false);
            }
            ActivateRandomBubble(bubblesCount);
        }

        private void ActivateRandomBubble(int bubblesCount)
        {
            _bubbles[_activatedBubbleIndex].SetActive(false);
            var randNum = Random.Range(0, bubblesCount);
            _bubbles[randNum].SetActive(true);
            _activatedBubbleIndex = randNum;
        }
        
        private void OnBubbleEntered()
        {
            _isInBubble = true;
        }

        private void OnBubbleExit()
        {
            _isInBubble = false;
        }
    }
}