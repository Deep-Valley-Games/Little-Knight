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

        private void Awake()
        {
            _enemyMovement = GetComponent<EnemyMovement>();
        }


        public EnemyData GetEnemyData() => enemyData;
        

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void StartChase()
        {
            _enemyMovement.StartChase();
        }
    }
}