using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;

public class SoftLandBehaviour : StateMachineBehaviour
{
    CharacterAudio audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<CharacterAudio>();
    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audioPlayer.Play(CharacterAudio.AudioType.Landing, true);
        var shakePreset = ProCamera2DShake.Instance.ShakePresets[1];
        ProCamera2DShake.Instance.Shake(shakePreset);
    }
}
