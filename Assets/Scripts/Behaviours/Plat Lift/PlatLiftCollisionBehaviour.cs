using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatLiftCollisionBehaviour : StateMachineBehaviour
{
    PlatLift platLift;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        platLift = animator.GetComponent<PlatLift>();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        platLift.isAnimating = false;
    }

}
