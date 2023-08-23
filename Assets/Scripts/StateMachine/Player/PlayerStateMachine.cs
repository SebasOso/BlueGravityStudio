using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

public class PlayerStateMachine : StateMachine
{   
    [field: SerializeField]
    public InputReader InputReader {get; private set;}

    [field: SerializeField]
    public Mover Mover {get; private set;}

    [field: SerializeField]
    public Animator Animator {get; private set;}

    [field: SerializeField]
    public PlayerInteract PlayerInteract{get; private set;}

    [field: SerializeField]
    public InventoryManager Inventory {get; private set;}

    [field: SerializeField]
    public NavMeshAgent NavMeshAgent {get; private set;}
    private void Start() 
    {
        SwitchState(new PlayerFreeLookState(this));
    }
}
