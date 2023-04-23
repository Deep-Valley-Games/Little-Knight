using UnityEngine;

namespace _Root.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Enemy Data", menuName = "New Enemy Data", order = 0)]
    public class EnemyData : ScriptableObject
    {
        public float movementSpeed = 10;
        public float attackRange = 3;
        public int health = 100;
        public int damage = 10;
       [Range(0.4f,2)] public float attackCooldown = 1;
        public float stoppingDistance = 1;
    }
}