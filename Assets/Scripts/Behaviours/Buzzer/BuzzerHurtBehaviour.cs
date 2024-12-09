using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuzzerHurtBehaviour : StateMachineBehaviour
{
    Buzzer buzzer;
    // OnStateEnter được gọi khi quá trình chuyển đổi bắt đầu và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buzzer = animator.GetComponent<Buzzer>();
    }

  // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại 
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit được gọi khi một quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buzzer.SwitchState(Buzzer.EnemyState.PATHFINDING);
    }

        // OnStateMove được gọi ngay sau Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK được gọi ngay sau Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
}
