using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingBehaviour : StateMachineBehaviour
{
    CharacterEffect effecter;

    private void Awake()
    {
        effecter = FindObjectOfType<CharacterEffect>();
    }

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        effecter.DoEffect(CharacterEffect.EffectType.DustJump, true);
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        effecter.DoEffect(CharacterEffect.EffectType.DustJump, false);
    }
}
