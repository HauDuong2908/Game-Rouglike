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

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại OnStateEnter và OnStateExit

    // OnStateExit được gọi khi quá trình chuyển đổi kết thúc và máy trạng thái kết thúc việc đánh giá trạng thái này
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        buzzer.SwitchState(Buzzer.EnemyState.PATHFINDING);
    }

    // OnStateMove được gọi ngay sau Animator.OnAnimatorMove()

    // OnStateIK được gọi ngay sau Animator.OnAnimatorIK()
}
