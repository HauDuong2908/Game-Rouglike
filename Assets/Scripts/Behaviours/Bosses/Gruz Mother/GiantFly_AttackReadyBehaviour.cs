using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantFly_AttackReadyBehaviour : StateMachineBehaviour
{
    GruzMother enemy;

    // OnStateEnter được gọi khi quá trình chuyển đổi bắt đầu và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemy = animator.GetComponent<GruzMother>();
    }

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại OnStateEnter và OnStateExit
    //ghi đè public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //
    //}

    // OnStateExit được gọi khi quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    // {

    // }

    // OnStateMove được gọi ngay sau Animator.OnAnimatorMove()
    //ghi đè public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    // // Triển khai mã xử lý và ảnh hưởng đến chuyển động của gốc
    //}

    // OnStateIK được gọi ngay sau Animator.OnAnimatorIK()
    //ghi đè public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    // // Triển khai mã thiết lập IK hoạt ảnh (động học ngược)
    //}
}
