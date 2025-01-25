using UnityEngine;

namespace Character
{
    public class DashSpecialEffect : MonoBehaviour
    {
        [SerializeField] private GameObject dashEffect;

        private void Start()
        {
            dashEffect.SetActive(false);
        }

        private void OnEnable()
        {
            CharacterEvents.Dash += OnDash;
        }

        private void OnDisable()
        {
            CharacterEvents.Dash -= OnDash;
        }

        private void OnDash(bool isDashing)
        {
            dashEffect.SetActive(isDashing);
        }
    }
}