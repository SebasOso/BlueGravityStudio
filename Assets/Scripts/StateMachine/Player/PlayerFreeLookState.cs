using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;

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
        stateMachine.Animator.CrossFadeInFixedTime(FreeLookBlendTree, CrossFadeDuration);
    }

    public override void Tick(float deltaTime)
    {
        Ray ray;
        RaycastHit hit;
        ray = Pointer.Instance.GetRayCursor();
        bool hasHit = Physics.Raycast(ray, out hit);
        if(hasHit)
        {
            if (Input.GetMouseButton(0))
            {
               Move(hit.point);
            }
        }
    }

    public override void Exit()
    {
       
    }
}
