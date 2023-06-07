using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Root.Scripts.Controllers
{
    public class PlayerHealthController : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        
        private readonly float _maxHealth = 100;
        private float _health;

        private void Awake()
        {
            GetValues();
        }

        private void Start()
        {
            UpdateInterface();
        }

        private void GetValues()
        {
            _health = PlayerPrefs.GetFloat("health", 100);
        }

        private void UpdateInterface()
        {
            var amount = _health / _maxHealth;
            healthBar.fillAmount = amount;
        }
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            if (_health<0)
            {
                _health = 0;
            }
            UpdateInterface();
        }

        public void GetHeal(int healValue)
        {
            _health += healValue;
            UpdateInterface();
        }
    }
}