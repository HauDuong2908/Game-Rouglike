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

    // OnStateUpdate được gọi trên mỗi khung Cập nhật giữa các lệnh gọi lại 
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (lastPositionY > character.transform.position.y)
        {
            fallDistance += lastPositionY - character.transform.position.y;
        }
        lastPositionY = character.transform.position.y;
        animator.SetFloat("FallDistance", fallDistance);
    }

    // OnStateExit được gọi khi một quá trình chuyển đổi kết thúc và máy trạng thái hoàn tất việc đánh giá trạng thái này
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.Falling, false);
    }

    public void ResetAllParams()
    {
        lastPositionY = character.transform.position.y;
        fallDistance = 0;
    }
}
