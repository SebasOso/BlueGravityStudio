using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractState : PlayerBaseState
{
    private readonly int ShopLookBlendTree = Animator.StringToHash("ShopBT");
    private const float AnimatorDampTime = 0.1f;
    private const float CrossFadeDuration = 0.1f;
    public PlayerInteractState(PlayerStateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void Enter()
    {
        stateMachine.InputReader.InteractEvent += OnCancelNPC;
        stateMachine.Animator.CrossFadeInFixedTime(ShopLookBlendTree, CrossFadeDuration);
        stateMachine.PlayerInteract.ShopUI?.SetActive(true);
    }

    public override void Tick(float deltaTime)
    {
        if(stateMachine.PlayerInteract.sellerNpc ==  null)
        {
            stateMachine.InputReader.IsMoving = true;
            stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
            return;
        }
        stateMachine.PlayerInteract.ShopIcon?.SetActive(false);
        stateMachine.NavMeshAgent.speed = 0f;
        stateMachine.InputReader.IsMoving = false;
        FaceTarget();
    }
    public override void Exit()
    {
        stateMachine.InputReader.InteractEvent -= OnCancelNPC;
    }
    private void OnCancelNPC()
    {
        //stateMachine.PlayerInteract.Cancel();
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
        stateMachine.PlayerInteract.ShopUI?.SetActive(false);
        stateMachine.PlayerInteract.ShopIcon?.SetActive(true);
    }
}
