using System;
using System.Collections.Generic;
using Character;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class AbilityInventoryUI : MonoBehaviour
    {
        [SerializeField] private List<Sprite> abilityIcons;
        [SerializeField] private Image lastAbilityIcon;
        [SerializeField] private Image previousAbilityIcon;


        private Transform _lastAbilityParent;
        private Transform _prevoiusAbilityParent;

        private void OnEnable()
        {
            UIEvents.AbilitiesUpdate += OnAbilitiesChanged;
        }

        private void OnDisable()
        {
            UIEvents.AbilitiesUpdate -= OnAbilitiesChanged;
        }

        private void Start()
        {
            _lastAbilityParent = lastAbilityIcon.transform.parent;
            _prevoiusAbilityParent = previousAbilityIcon.transform.parent;
            _lastAbilityParent.gameObject.SetActive(false);
            _prevoiusAbilityParent.gameObject.SetActive(false);
        }

        private void OnAbilitiesChanged(List<Abilities> abilities)
        {
            print("Abilities changed");
            if (abilities.Count == 0)
            {
                _lastAbilityParent.gameObject.SetActive(false);
                _prevoiusAbilityParent.gameObject.SetActive(false);
                return;
            }
            
            _lastAbilityParent.gameObject.SetActive(true);
            lastAbilityIcon.sprite = abilityIcons[(int)abilities[^1]];
            
            if (abilities.Count <= 1) 
                return;
            
            _prevoiusAbilityParent.gameObject.SetActive(true);
            previousAbilityIcon.sprite = abilityIcons[(int)abilities[^2]];
        }
    }
}