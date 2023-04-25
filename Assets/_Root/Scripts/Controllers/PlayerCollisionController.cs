using System;
using _Root.Scripts.Signals;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerCollisionController : MonoBehaviour
    {
        private bool _onLand;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Plane"))
            {
                MovementSignals.Instance.OnAir?.Invoke(false);
            }
        }
        
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Plane"))
            {
                MovementSignals.Instance.OnAir?.Invoke(true);
            }
        }
        
        
    }
}
