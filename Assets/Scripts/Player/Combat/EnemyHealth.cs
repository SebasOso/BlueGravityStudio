using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Combat
{
    public class EnemyHealth : MonoBehaviour
    {
        private bool isDead = false;
        [SerializeField] private float health = 100f;

        //Method to be called in the enemy when he gets hit punched by the player
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            GetComponent<Animator>().SetTrigger("hit");
            print(health);
            if(health == 0)
            {
                CallRagdollPunch();
            }
        }

        //Method to be called when the enemy is dead and activate the ragdoll with the variables in PunchLogic
        private void CallRagdollPunch()
        {
            if(isDead) return;
            isDead = true;
            GetComponent<CombatTarget>().TriggerRagdoll(PunchLogic.Instance.force, PunchLogic.Instance.forceDirection);
        }
        public bool IsDead()
        {
            return isDead;
        }
    }
}
