using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFly_AttackReadyBehaviour : StateMachineBehaviour
{
    GruzMother enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<GruzMother>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
