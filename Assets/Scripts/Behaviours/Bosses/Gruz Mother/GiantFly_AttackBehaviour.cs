using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFly_AttackBehaviour : StateMachineBehaviour
{
    GruzMother enemy;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<GruzMother>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (enemy.CanResumeCrash())
        {
            enemy.SwitchState(GruzMother.EnemyState.ATTACK_PATHFINDING);
        }
        else
        {
            enemy.SwitchState(GruzMother.EnemyState.FLY);
        }
    }
}
