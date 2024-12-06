using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDrip_IdleBehaviour : StateMachineBehaviour
{
    [SerializeField]
    private float minReadyDrip, maxReadyDrip;
    private float lastReadyDripTime, readyDripTime;
    private WaterDrip drip;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (drip == null)
            drip = animator.GetComponent<WaterDrip>();

        readyDripTime = Random.Range(minReadyDrip, maxReadyDrip);
        lastReadyDripTime = Time.time + readyDripTime;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time >= +lastReadyDripTime)
        {
            animator.SetTrigger("Drop");
        }
    }
}
