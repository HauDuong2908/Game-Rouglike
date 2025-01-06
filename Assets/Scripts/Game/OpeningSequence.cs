using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningSequence : MonoBehaviour
{
    [SerializeField] private VideoPlayer prologue;
    [SerializeField] private VideoPlayer intro;

    private AnyKeyTip anyKeyTip;
    private CrossFader crossFader;

    private void Awake()
    {
        anyKeyTip = FindObjectOfType<AnyKeyTip>();
        crossFader = FindObjectOfType<CrossFader>();
    }

    private void Start()
    {
        // Debugging: Kiểm tra và đảm bảo VideoPlayer đã được cấu hình đúng
        CheckVideoPlayer(prologue, "Prologue");
        CheckVideoPlayer(intro, "Intro");

        prologue.loopPointReached += ProloguePlayer_loopPointReached;
        intro.loopPointReached += IntroPlayer_loopPointReached;
        
        // Nếu chưa chuẩn bị, hãy chuẩn bị trước khi phát.
        if (!intro.isPrepared)
        {
            Debug.Log("Preparing intro video...");
            intro.Prepare();
        }
    }

    public void PlayPrologue()
    {
        ResetAnyKeyTip();
        prologue.Play();
    }

    private void ProloguePlayer_loopPointReached(VideoPlayer source)
    {
        UpdateAnyKeyTipCounter();
        ResetAnyKeyTip();
        intro.Play();
    }

    private void IntroPlayer_loopPointReached(VideoPlayer source)
    {
        UpdateAnyKeyTipCounter();
        ResetAnyKeyTip();
        crossFader.FadeIn();

        // Debugging: Kiểm tra video đã sẵn sàng và đang phát đúng cách
        Debug.Log($"Intro video playback completed. Is video prepared: {intro.isPrepared}");
        
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadSceneAsync(1);
        }
    }

    public void UpdateAnyKeyTipCounter()
    {
        anyKeyTip.counter++;
    }

    public void ResetAnyKeyTip()
    {
        anyKeyTip.ResetAnyKeyTip();
    }

    // Hàm kiểm tra VideoPlayer
    private void CheckVideoPlayer(VideoPlayer player, string videoName)
    {
        if (player == null)
        {
            Debug.LogError($"{videoName} VideoPlayer is missing!");
            return;
        }

        if (!player.isPrepared)
        {
            Debug.LogWarning($"{videoName} is not prepared yet.");
        }
        else
        {
            Debug.Log($"{videoName} is prepared and ready to play.");
        }

        // Kiểm tra RenderMode và TargetTexture
        Debug.Log($"{videoName} RenderMode: {player.renderMode}");
        Debug.Log($"{videoName} TargetTexture: {player.targetTexture}");

        if (player.renderMode != VideoRenderMode.RenderTexture || player.targetTexture == null)
        {
            Debug.LogError($"{videoName} is not set to use a RenderTexture correctly!");
        }
    }
}
