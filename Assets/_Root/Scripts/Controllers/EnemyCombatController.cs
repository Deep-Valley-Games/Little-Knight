using _Root.Scripts.Interfaces;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class EnemyCombatController: MonoBehaviour
    {
        private bool _isDied;
        
        public void TakeDamage()
        {
            //Play Hit Animation
            
            if(!_isDied)
                return;
            Die();
        }

        public void Die()
        {
            //Play Death Animation
            Debug.Log("DIED");
            //Disable The Enemy
        }
    }
}