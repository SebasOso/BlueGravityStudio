using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] public GameObject ShopUI;
    [SerializeField] public GameObject ShopIcon;
    [field: SerializeField]public NPCInteractable sellerNpc{get;private set;}
    private void OnTriggerEnter(Collider other) 
    {
        if (!other.TryGetComponent<NPCInteractable>(out NPCInteractable npc))
        {
           return;
        }
        sellerNpc = npc;
        ShopIcon.SetActive(true);
    }
    private void OnTriggerExit(Collider other) 
    {
        if (!other.TryGetComponent<NPCInteractable>(out NPCInteractable npc))
        {
            return;
        } 
        RemoveNPC(npc);
        ShopIcon.SetActive(false);
    }
    public bool SelectTarget()
    {
        if(sellerNpc == null){return false;}
        ShopIcon?.SetActive(true);
        return true;
    }
    public void Cancel()
    {
        if(sellerNpc == null){return;}
        sellerNpc = null;
    }
    private void RemoveNPC(NPCInteractable npcToRemove)
    {
        sellerNpc = null;
    }
}
