using UnityEngine;

public class FallingBehaviour : StateMachineBehaviour
{
    float lastPositionY, fallDistance;
    CharacterAudio audioPlayer;
    CharacterController2D character;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
        character = FindObjectOfType<CharacterController2D>();
    }

    // OnStateEnter được gọi khi quá trình chuyển đổi bắt đầu và máy trạng thái bắt đầu đánh giá trạng thái này
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        fallDistance = 0;
        animator.SetFloat("FallDistance", fallDistance);

        audioPlayer.Play(CharacterAudio.AudioType.Falling, true);
    }

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại OnStateEnter và OnStateExit
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (lastPositionY > character.transform.position.y)
        {
            fallDistance += lastPositionY - character.transform.position.y;
        }
        lastPositionY = character.transform.position.y;
        animator.SetFloat("FallDistance", fallDistance);
    }

    // OnStateExit được gọi khi quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.Falling, false);
    }

    // OnStateMove được gọi ngay sau Animator.OnAnimatorMove()
    //ghi đè public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    // Triển khai mã xử lý và ảnh hưởng đến chuyển động của gốc
    //}

    // OnStateIK được gọi ngay sau Animator.OnAnimatorIK()
    //ghi đè public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    // Triển khai mã thiết lập IK hoạt ảnh (động học ngược)
    //}

    public void ResetAllParams()
    {
        lastPositionY = character.transform.position.y;
        fallDistance = 0;
    }
}
