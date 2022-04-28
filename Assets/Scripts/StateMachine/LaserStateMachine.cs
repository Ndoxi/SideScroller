using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class LaserStateMachine : StateMachineBehaviour
{
    public static Action FireLaserAction;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FireLaserAction?.Invoke();
        animator.enabled = false;
    }
}
