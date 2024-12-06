using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieRunnerHurtBehaviour : StateMachineBehaviour
{
    ZombieRunner runner;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        runner = animator.GetComponent<ZombieRunner>();
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        runner.SwitchState(ZombieRunner.EnemyState.MOVEMENT);
    }

}
