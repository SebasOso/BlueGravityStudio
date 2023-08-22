using System.Collections;
using System.Collections.Generic;
using RPG.Movement;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField]
    public Mover Mover {get; private set;}

    [field: SerializeField]
    public Animator Animator {get; private set;}

    private void Start() 
    {
        SwitchState(new PlayerFreeLookState(this));
    }
}
