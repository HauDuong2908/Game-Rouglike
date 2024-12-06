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

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại OnStateEnter và OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
