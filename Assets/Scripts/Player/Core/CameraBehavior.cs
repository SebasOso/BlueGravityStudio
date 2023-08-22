using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Core
{
    public class CameraBehavior : MonoBehaviour
    {
        [SerializeField] private Transform target;
        void Update()
        {
            transform.position = target.position;
        }
    }
}