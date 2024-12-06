using UnityEngine;

public class KnightRunBehaviour : StateMachineBehaviour
{
    CharacterAudio audioPlayer;
    CharacterEffect effecter;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
        effecter = FindObjectOfType<CharacterEffect>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.FootstepsRun, true);
        effecter.DoEffect(CharacterEffect.EffectType.RoarDust, true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.FootstepsRun, false);
        effecter.DoEffect(CharacterEffect.EffectType.RoarDust, false);
    }
}
