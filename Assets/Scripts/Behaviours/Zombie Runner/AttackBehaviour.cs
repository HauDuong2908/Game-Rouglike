using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : StateMachineBehaviour
{
    ZombieRunner runner;
    ParticleSystem lift;
    int constantTime = 2;
    float switchNextStateTimer;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lift = animator.GetComponentInChildren<ParticleSystem>();
        runner = animator.GetComponent<ZombieRunner>();
        runner.PlayZombieChase();
        runner.SwitchState(ZombieRunner.EnemyState.ATTACK);
        switchNextStateTimer = Time.time + constantTime;
        lift.Play();
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > switchNextStateTimer)
        {
            runner.SwitchState(ZombieRunner.EnemyState.MOVEMENT);
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        lift.Stop();
    }
}
