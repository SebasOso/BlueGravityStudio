using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using UnityEngine.Rendering;

public class PlayerFreeLookState : PlayerBaseState
{
    private readonly int FreeLookSpeedHash = Animator.StringToHash("speed");
    private readonly int FreeLookBlendTree = Animator.StringToHash("LocomotionBT");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public PlayerFreeLookState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.InputReader.InventoryEvent += OnInventory;
        stateMachine.InputReader.InteractEvent += OnInteract;
        stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTree, CrossFadeDuration);
    }
    public override void Tick(float deltaTime)
    {
        stateMachine.NavMeshAgent.speed = 3.5f;
        if(stateMachine.InputReader.IsMoving)
        {
            OnMove();
        }
    }

    public override void Exit()
    {
        stateMachine.InputReader.InteractEvent -= OnInteract;
        stateMachine.InputReader.InventoryEvent -= OnInventory;
    }
    private void OnInteract()
    {
        if(!stateMachine.PlayerInteract.SelectTarget()){return;}
        stateMachine.SwitchState(new PlayerInteractState(stateMachine));
    }
    private void OnMove()
    {
        Ray ray;
        RaycastHit hit;
        ray = Pointer.Instance.GetRayCursor();
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            Move(hit.point);
        }
    }
    private void OnInventory()
    {
        stateMachine.SwitchState(new PlayerInventoryState(stateMachine));
    }
}
