using UnityEngine;

public class SlideBehaviour : StateMachineBehaviour
{
    CharacterController2D character;
    CharacterEffect effecter;
    CharacterAudio audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
        effecter = FindObjectOfType<CharacterEffect>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (character == null)
            character = animator.GetComponent<CharacterController2D>();
        audioPlayer.Play(CharacterAudio.AudioType.WallSlide, true);
        effecter.DoEffect(CharacterEffect.EffectType.WallSlideDust, true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (character == null)
            character = animator.GetComponent<CharacterController2D>();
        audioPlayer.Play(CharacterAudio.AudioType.WallSlide, false);
        effecter.DoEffect(CharacterEffect.EffectType.WallSlideDust, false);
        character.SlideWall_ResetJumpCount();
    }
}
