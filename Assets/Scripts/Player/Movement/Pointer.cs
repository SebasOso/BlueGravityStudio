using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Movement
{
    public class Pointer : MonoBehaviour
    {
        public static Pointer Instance {get; private set;}
        private void Awake() 
        {
            Instance = this;
        }
        public Ray GetRayCursor()
        {
            Ray ray;
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return ray;
        }
    }
}
