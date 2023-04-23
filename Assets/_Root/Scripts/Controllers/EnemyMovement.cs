using System;
using _Root.Scripts.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class EnemyMovement : MonoBehaviour
    {
        private EnemyController _enemyController;
        private EnemyData _enemyData;
        private float _movementSpeed;
        private float _stoppingDistance;
        private Transform _target;
        private bool _onTarget;
    
        private void Awake()
        {
            _enemyController = GetComponent<EnemyController>();
            _enemyData = _enemyController.GetEnemyData();
            _target = GameObject.Find("Player").transform;
        }

        private void Start()
        {
            _movementSpeed = _enemyData.movementSpeed;
            _stoppingDistance = _enemyData.stoppingDistance;

        }

        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            _onTarget = Vector2.Distance(transform.position, _target.position) <= _stoppingDistance;
            if(_onTarget)
                return;
            if (_target)
            {
                // transform.position = Vector2.Lerp(transform.position,
                //     new Vector2(_target.position.x, transform.position.y),
                //     _movementSpeed * Time.deltaTime);

                var direction = Mathf.Sign(_target.position.x - transform.position.x);
                var lookRotation = 0;
                if (direction<0)
                {
                    lookRotation = -180;
                }
                transform.rotation = Quaternion.Euler(transform.rotation.x, lookRotation, 0);
                transform.Translate(_movementSpeed * Time.deltaTime,
                    0, 0);
            }
        }
    }
}