using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    ZombieRunner runner;
    int minRandomTime = 2, maxRandomTime = 3;
    float switchNextStateTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        runner = animator.GetComponent<ZombieRunner>();
        switchNextStateTimer = Time.time + Random.Range(minRandomTime, maxRandomTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > switchNextStateTimer)
        {
            animator.SetTrigger("Movement");
            runner.SwitchState(ZombieRunner.EnemyState.MOVEMENT);
        }
    }
}
