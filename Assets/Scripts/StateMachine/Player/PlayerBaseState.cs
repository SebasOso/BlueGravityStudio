using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected PlayerStateMachine stateMachine;

    public PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    public void Move(Vector3 destinationVector)
    {
        stateMachine.Mover.MoveTo(destinationVector);
    }
    protected void FaceTarget()
    {
        if(stateMachine.PlayerInteract.sellerNpc == null){return;}
        Vector3 targetDirection = (stateMachine.PlayerInteract.sellerNpc.transform.position - stateMachine.transform.position);
        targetDirection.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        float rotationSpeed = 1.4f; 
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
