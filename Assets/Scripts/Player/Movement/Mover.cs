using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        //Logic for move the player with the cursor.
        
        [SerializeField] private Animator anim;
        public NavMeshAgent navMesh;
        public static Mover Instance {get; private set;}
        private void Awake() 
        {
            Instance = this;
        }
        private void Start() 
        {
            navMesh = gameObject.GetComponent<NavMeshAgent>();
        }
        void Update()
        {
            UpdateAnimator();
        }
        public void StartMoveAction(Vector3 destination)
        {
            MoveTo(destination);
        }
        public void MoveTo(Vector3 destination)
        {
            navMesh.SetDestination(destination);
            navMesh.isStopped = false;
        }
        private void UpdateAnimator()
        {
            Vector3 velocity = gameObject.GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            anim.SetFloat("forwardSpeed", speed);
        }
    }
}
