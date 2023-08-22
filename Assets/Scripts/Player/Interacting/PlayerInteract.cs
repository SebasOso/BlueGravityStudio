using System.Collections;
using System.Collections.Generic;
using RPG.Core;
using UnityEngine;

public class PlayerInteract : MonoBehaviour, IAction
{
    [SerializeField]
    float interactRange = 2f;
    void Update()
    {
        Interact();
    }
    private void Interact()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
            foreach (Collider collider in colliderArray)
            {
                if(collider.TryGetComponent<NPCInteractable>(out NPCInteractable npc))
                {
                    npc.Interact();
                    Debug.Log(collider);
                }
            }
        }
    }

    public void Cancel()
    {
        
    }
}
