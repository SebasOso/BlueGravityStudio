using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Combat;
using System;

namespace RPG.Control
{
    public class PlayerController : MonoBehaviour
    {
        void Update()
        {
            if(InteractWithMovement()) return;
        }
        //Method for the logic of movement
        private bool InteractWithMovement()
        {
            Ray ray;
            RaycastHit hit;
            ray = Pointer.Instance.GetRayCursor();
            bool hasHit = Physics.Raycast(ray, out hit);
            if(hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().StartMoveAction(hit.point);
                }
                if(hit.transform.CompareTag("WaterPlane"))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}
