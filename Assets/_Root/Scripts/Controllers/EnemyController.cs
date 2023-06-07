using System;
using _Root.Scripts.Interfaces;
using _Root.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class EnemyController : MonoBehaviour, IEnemy
    {
        [SerializeField] private EnemyData enemyData;

        private EnemyMovement _enemyMovement;
        private EnemyCombatController _combatController;
        private float _health;

        private void Awake()
        {
            _combatController = GetComponent<EnemyCombatController>();
            _enemyMovement = GetComponent<EnemyMovement>();
            _health = enemyData.health;
        }


        public EnemyData GetEnemyData() => enemyData;
        

        public void TakeDamage(int damage)
        {
            _health -= damage;
            _health = Mathf.Clamp(_health, 0, 1000);

            var isDead = _health <= 0;
            
            if (isDead)
            {
                _combatController.Die();
                _enemyMovement.enabled = false;
                this.enabled = false;
            }
            else
            {
                _combatController.TakeDamage();
            }
        }

        public void StartChase()
        {
            _enemyMovement.StartChase();
        }
    }
}