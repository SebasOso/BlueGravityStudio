using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Combat
{
    public class PunchLogic : MonoBehaviour
    {
        [SerializeField] private GameObject punch;
        [SerializeField] private float rayDistance;
        [SerializeField] private float punchForce;
        [SerializeField] private bool touchedEnemy;
        [SerializeField] private CombatTarget lastEnemyHitted;
        [SerializeField] public Vector3 forceDirection;
        [SerializeField] public Vector3 force;
        public static PunchLogic Instance {get; private set;}
        private void Awake() 
        {
            Instance = this;
        }
        private void Update() 
        {
            //Draws a raycast in the hand of the player to recognize the enemy and the part of the body
            RaycastHit hit;
            if (Physics.Raycast(punch.transform.position, punch.transform.right, out hit, rayDistance))
            {
                Debug.Log(hit.transform.name);
                CombatTarget enemy = hit.collider.GetComponentInParent<CombatTarget>();
                if(enemy != null)
                {
                    //Set the info of the punch logic that we need in the ragdoll of the enemy
                    lastEnemyHitted = enemy;
                    touchedEnemy = true;
                    forceDirection = enemy.transform.position - this.transform.position;
                    forceDirection.y = 1;
                    forceDirection.Normalize();
                    force = punchForce * forceDirection;
                }
                else
                {
                    touchedEnemy = false;  // Reset if something other than an enemy is hit
                }
            }
            else
            {
                touchedEnemy = false;  // Reset if nothing is hit
            }
        }
    }
}

