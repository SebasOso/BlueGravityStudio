using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RPG.Movement
{
    public class Pointer : MonoBehaviour
    {
        Vector3 mosWorldPos;
        public static Pointer Instance {get; private set;}
        private void Awake() 
        {
            Instance = this;
        }
        public Ray GetRayCursor()
        {
            mosWorldPos = Mouse.current.position.ReadValue();
            Ray ray;
            ray = Camera.main.ScreenPointToRay(mosWorldPos);
            return ray;
        }
    }
}
