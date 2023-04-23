using _Root.Scripts.ScriptableObjects;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private EnemyData enemyData;


        public EnemyData GetEnemyData() => enemyData;
    }
}