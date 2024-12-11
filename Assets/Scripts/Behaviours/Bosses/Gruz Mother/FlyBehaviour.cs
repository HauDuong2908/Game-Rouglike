using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyBehaviour : StateMachineBehaviour
{
    Transform player;
    GruzMother boss;

    // OnStateEnter được gọi khi quá trình chuyển đổi bắt đầu và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        boss = animator.GetComponent<GruzMother>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateExit được gọi khi một quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này
    //{
    //    
    //}

    // OnStateMove được gọi ngay sau Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK được gọi ngay sau Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
