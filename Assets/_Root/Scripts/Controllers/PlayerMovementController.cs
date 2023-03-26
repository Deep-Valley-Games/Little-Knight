using System;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed, jumpForce; //5-10

        private Rigidbody2D _rb;
        private bool _onAir;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        private void Move()
        {
            if (Input.GetKey(KeyCode.A))
            {
                _rb.velocity = new Vector2(-movementSpeed, _rb.velocity.y);
                transform.rotation=Quaternion.Euler(new Vector3(transform.rotation.x,0,transform.rotation.z));
            }
            if (Input.GetKey(KeyCode.D))
            {
                _rb.velocity = new Vector2(movementSpeed, _rb.velocity.y);
                transform.rotation=Quaternion.Euler(new Vector3(transform.rotation.x,180,transform.rotation.z));
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                if(_onAir)
                    return;
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            }
   
        }

        private void Update()
        {
            Move();
        }
    }
}
