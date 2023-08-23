using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public event Action InventoryEvent;
    public event Action InteractEvent;
    public bool IsMoving {get;set;}
    private Controls controls;
    void Start()
    {
        if(controls == null)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);

            controls.Player.Enable();
        }
    }
    public void OnInteract(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            return;
        }
        InteractEvent?.Invoke();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(!context.performed)
        {
            return;
        }
        InventoryEvent?.Invoke();
    }
}
