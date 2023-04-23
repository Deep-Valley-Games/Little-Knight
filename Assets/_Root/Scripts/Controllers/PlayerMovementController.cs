using _Root.Scripts.Signals;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] private float movementSpeed, jumpForce; //5-10
        [SerializeField] private Transform mesh;

        private Rigidbody2D _rb;
        private bool _onAir;

        private void Awake()
        {
            _rb = transform.root.GetComponent<Rigidbody2D>();
        }

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            MovementSignals.Instance.OnAir += AirStatus;
        }

        private void UnSubscribe()
        {
            MovementSignals.Instance.OnAir -= AirStatus;
        }
        #endregion

        private void Move()
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                var rotation = mesh.rotation;
                
                _rb.velocity = new Vector2(-movementSpeed, _rb.velocity.y);
                rotation=Quaternion.Euler(new Vector3(rotation.x,0,rotation.z));
                mesh.rotation = rotation;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                var rotation = mesh.rotation;
                
                _rb.velocity = new Vector2(movementSpeed, _rb.velocity.y);
                rotation=Quaternion.Euler(new Vector3(rotation.x,180,rotation.z));
                mesh.rotation = rotation;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
            {
                if(_onAir)
                    return;
                _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
            }
        }   

        private void AirStatus(bool onAir)
        {
            _onAir = onAir;
        }

        private void Update()
        {
            Move();
        }
    }
}
