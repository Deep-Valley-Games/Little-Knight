using _Root.Scripts.Interfaces;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class Scanner : MonoBehaviour
    {
        [SerializeField] private float scanRadius;
        [SerializeField] private LayerMask scanLayer;

        private Collider2D[] _scannedEnemies = new Collider2D[10];

        private void OnDrawGizmosSelected()
        {
            Gizmos.color=Color.magenta;
            Gizmos.DrawWireSphere(transform.position, scanRadius);
        }
        private void ScanTheArea()
        {
            _scannedEnemies = Physics2D.OverlapCircleAll(transform.position, scanRadius, scanLayer,-1000,1000);

            foreach (var enemy in _scannedEnemies)
            {
                if (enemy.transform.parent.TryGetComponent(out IEnemy iFace))
                {
                    iFace.StartChase();
                }
            }
        }

        private void Update()
        {
            ScanTheArea();
        }
        
    }
}