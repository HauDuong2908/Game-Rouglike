using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardLandBehaviour : StateMachineBehaviour
{
    CharacterAudio sound;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {        
        // Hiệu ứng rung máy
        var shakePreset = ProCamera2DShake.Instance.ShakePresets[2];
        ProCamera2DShake.Instance.Shake(shakePreset);
        if (sound == null)
            FindObjectOfType<CharacterAudio>().Play(CharacterAudio.AudioType.HardLanding, true);
        else
            sound.Play(CharacterAudio.AudioType.HardLanding, true);
    }
}
