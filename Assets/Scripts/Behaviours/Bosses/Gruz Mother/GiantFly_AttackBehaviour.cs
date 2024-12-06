using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFly_AttackBehaviour : StateMachineBehaviour
{
    GruzMother enemy;

    // OnStateEnter được gọi khi quá trình chuyển đổi bắt đầu và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<GruzMother>();
    }

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại OnStateEnter và OnStateExit

    // OnStateExit được gọi khi quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này
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

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
