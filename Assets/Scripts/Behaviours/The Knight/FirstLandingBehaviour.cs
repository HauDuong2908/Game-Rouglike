using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstLandingBehaviour : StateMachineBehaviour
{
    CharacterAudio sound;
    ParticleSystem flockParticle;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (sound == null)
            FindObjectOfType<CharacterAudio>().Play(CharacterAudio.AudioType.HardLanding, true);
        else
            sound.Play(CharacterAudio.AudioType.HardLanding, true);
        // Hiệu ứng rung máy.
        var shakePreset = ProCamera2DShake.Instance.ShakePresets[0];
        ProCamera2DShake.Instance.Shake(shakePreset);
        GameObject flock = GameObject.Find("Flock");
        if (flock != null)
        {
            flockParticle = GameObject.Find("Flock").GetComponent<ParticleSystem>();
            flockParticle.Play();
        }
        FindObjectOfType<SoulOrb>().DelayShowOrb(2);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("FirstLanding", true);
        FindObjectOfType<GameManager>().SetEnableInput(true);
    }
}
