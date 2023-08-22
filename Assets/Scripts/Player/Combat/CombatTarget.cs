using UnityEngine;
using System.Linq;
using System.Collections;
using UnityEngine.AI;
namespace RPG.Combat
{
    public class CombatTarget : MonoBehaviour 
    {
        //The logic of the ragdoll of the enemy
        private Rigidbody[] ragdollBodies;
        private void Awake() 
        {
            ragdollBodies = GetComponentsInChildren<Rigidbody>();  
            DisableRagdoll();
        }
        private void DisableRagdoll()
        {
            foreach (Rigidbody rbRagdoll in ragdollBodies)
            {
                rbRagdoll.isKinematic = true;
            }
        }
        private void EnableRagdoll()
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
             foreach (Rigidbody rbRagdoll in ragdollBodies)
            {
                rbRagdoll.isKinematic = false;
            }
        }
        
        //Method to be called when the enemy gets killed
        public void TriggerRagdoll(Vector3 force, Vector3 hitPoint)
        {
            EnableRagdoll();
            Rigidbody hitRigidBody = ragdollBodies.OrderBy(rigidBody => Vector3.Distance(rigidBody.position, hitPoint)).First();
            hitRigidBody.AddForceAtPosition(force, hitPoint, ForceMode.Impulse);
        }
    }
}