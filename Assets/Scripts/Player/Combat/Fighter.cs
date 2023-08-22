using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;
namespace RPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [Header("Damage")]
        [SerializeField] private float weaponRange = 2f;
        [SerializeField] private float timeBetweenAttacks = 1.0f;
        EnemyHealth combatTarget;
        [SerializeField] float timeSinceLastAttack = 0;
        
        [Header("Animation")]
        [SerializeField] private Animator animator;
        [SerializeField] private float rotationSpeed;

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;

            //If we do not have an enemy to attack           
            if(combatTarget == null) return;

            //Also if the enemy is dead
            if(combatTarget.IsDead()) return;

            //If we have an enemy to attack, but we are not in range
            if (!GetIsInRange())
            {
                this.GetComponent<Mover>().MoveTo(combatTarget.transform.position);
            }

            //If we have an enemy to attack and we are in range
            else
            {
                AttackBehaviour();
            }
        }

        //Behavior to be called when we are attacking an enemy
        private void AttackBehaviour()
        {
            var targetRotation = Quaternion.LookRotation(combatTarget.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            //transform.LookAt(combatTarget.transform);
            if(timeSinceLastAttack > timeBetweenAttacks)
            {
                TriggerAttack();
                timeSinceLastAttack = 0;
            }
        }

        private void TriggerAttack()
        {
            animator.ResetTrigger("stopAttack");
            animator.SetTrigger("attack");
        }

        //Method to know if we are in range of the enemy
        private bool GetIsInRange()
        {
            return Vector3.Distance(gameObject.transform.position, combatTarget.transform.position) < weaponRange;
        }

        //Method to be called when attack an enemy an then call the IAction to cancel the other action
        public void Attack(CombatTarget combatTarget)
        {
            this.combatTarget = combatTarget.GetComponent<EnemyHealth>();
            print("Im gonna put some dirt in your eye...");
            GetComponent<ActionSchedular>().StartAction(this);
        }

        //Method of IAction to be called when cancel the action of fight
        public void Cancel()
        {
            TriggerStopAttack();
            combatTarget = null;
        }

        private void TriggerStopAttack()
        {
            animator.ResetTrigger("attack");
            animator.SetTrigger("stopAttack");
        }

        //Animation Event
        void Hit()
        {
            if(combatTarget == null)
            {
                return;
            }
            combatTarget.TakeDamage(20);
        }

        //Method called to know if we can attack or not to ignore dead enemies
        public bool CanAttack(CombatTarget combatTarget)
        {
            if(combatTarget == null) 
            {
                return false;
            }
            EnemyHealth targetHealth = combatTarget.GetComponent<EnemyHealth>();
            return targetHealth != null && !targetHealth.IsDead();
        }
    }
}
