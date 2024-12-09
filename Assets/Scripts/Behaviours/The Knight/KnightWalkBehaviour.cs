using UnityEngine;

public class KnightWalkBehaviour : StateMachineBehaviour
{
    CharacterAudio audioPlayer;
    CharacterEffect effecter;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
        effecter = FindObjectOfType<CharacterEffect>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.FoorstepsWalk, true);
        effecter.DoEffect(CharacterEffect.EffectType.RoarDustLil, true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.FoorstepsWalk, false);
        effecter.DoEffect(CharacterEffect.EffectType.RoarDustLil, false);
    }
}
