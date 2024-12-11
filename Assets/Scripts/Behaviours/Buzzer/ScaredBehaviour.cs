using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredBehaviour : StateMachineBehaviour
{
    Buzzer buzzer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buzzer = animator.GetComponent<Buzzer>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buzzer.SwitchState(Buzzer.EnemyState.PATHFINDING);
    }
}
