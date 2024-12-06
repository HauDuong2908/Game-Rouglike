using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : StateMachineBehaviour
{
    ZombieRunner runner;
    int minRandomTime = 2, maxRandomTime = 6;
    float switchNextStateTimer;
    AudioSource audioSource;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (audioSource == null)
            audioSource = animator.GetComponent<AudioSource>();
        audioSource.Play();
        runner = animator.GetComponent<ZombieRunner>();
        switchNextStateTimer = Time.time + Random.Range(minRandomTime, maxRandomTime);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > switchNextStateTimer)
        {
            animator.SetTrigger("Idle");
            runner.SwitchState(ZombieRunner.EnemyState.IDLE);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (audioSource == null)
            audioSource = animator.GetComponent<AudioSource>();
        audioSource.Stop();
    }
}
