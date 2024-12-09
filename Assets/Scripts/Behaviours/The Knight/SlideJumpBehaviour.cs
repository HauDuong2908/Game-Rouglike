using UnityEngine;

public class SlideJumpBehaviour : StateMachineBehaviour
{
    CharacterAudio audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.WallJump, true);
    }
}
