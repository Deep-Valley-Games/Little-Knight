using System;
using _Root.Scripts.Interfaces;
using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class PlayerCombatController : MonoBehaviour
    {
        [SerializeField] private int damage = 40;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackRange;
        [SerializeField] private LayerMask enemyLayers;
        [SerializeField] private float attackCooldown = 2;
        [SerializeField] private Animator animator;
        
        private float _attackTime;
        private Collider2D[] _enemyColliders = new Collider2D[10];
        private static readonly int Attack1 = Animator.StringToHash("Attack");


        private void Update()
        {
            CheckInput();
        }

        private void CheckInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
        }
        
        private void Attack()
        {
            if (Time.time < _attackTime) 
                return;
            
            PlayAttackAnimation();
            ScanTheAttackRange();
            GiveDamage(_enemyColliders);
            _attackTime = Time.time + 1f / attackCooldown;
        }

        private void PlayAttackAnimation()
        {
            animator.SetTrigger(Attack1);
        }

        private void GiveDamage(Collider2D[] enemyColliders)
        {
            if (_enemyColliders.Length<1)
                return;

            foreach (var enemy in enemyColliders)
            {
                if (enemy.transform.parent.TryGetComponent(out IEnemy iFace))
                {
                    iFace.TakeDamage(damage);
                }
            }
        }

        private void ScanTheAttackRange()
        {
            _enemyColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        }

        private void OnDrawGizmosSelected()
        {
            if(!attackPoint)
                return;
            
            Gizmos.color=Color.red;
            Gizmos.DrawWireSphere(attackPoint.position,attackRange);
        }
    }
}