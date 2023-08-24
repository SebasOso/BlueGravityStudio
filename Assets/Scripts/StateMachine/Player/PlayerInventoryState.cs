using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryState : PlayerBaseState
{
    
    private readonly int InventoryLookBlendTree = Animator.StringToHash("InventoryBT");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public PlayerInventoryState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }
    public override void Enter()
    {
        stateMachine.InputReader.InventoryEvent += OnCancelInventory;
        stateMachine.Animator.CrossFadeInFixedTime(InventoryLookBlendTree, CrossFadeDuration);
        stateMachine.Inventory.inventoryUI.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {
        stateMachine.InputReader.IsMoving = false;
        stateMachine.NavMeshAgent.speed = 0f;
        stateMachine.Inventory.inventoryIcon?.SetActive(false);
        stateMachine.PlayerInteract.ShopIcon?.SetActive(false);
    }
    public override void Exit()
    {
        stateMachine.InputReader.InventoryEvent -= OnCancelInventory;
    }
    private void OnCancelInventory()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        stateMachine.Inventory.inventoryUI.SetActive(false);
        stateMachine.Inventory.inventoryIcon?.SetActive(true);
        if(stateMachine.PlayerInteract.sellerNpc != null)
        {
            stateMachine.PlayerInteract.ShopIcon.SetActive(true);
        }
        else
        {
            stateMachine.PlayerInteract.ShopIcon.SetActive(false);
        }
    }
}
