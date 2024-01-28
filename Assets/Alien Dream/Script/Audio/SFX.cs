using System.Collections;
using UnityEngine;

public class SFX : MonoSingleton<SFX>
{
    AudioSource bgm;
    Coroutine switch_bgm_coro = null;

    public AudioRes AudioRes;

    public void PlaySound(AudioClip clip, float volume = 1.0f){
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }

    void Awake(){
        bgm = gameObject.AddComponent<AudioSource>();
    }

    public void SwitchBGM(AudioClip clip){
        if(switch_bgm_coro != null){
            Debug.Log("正在切换另一组BGM，中断之前的切换");
            StopCoroutine(switch_bgm_coro);
        }
        switch_bgm_coro = StartCoroutine(SwitchBGM_Coro(clip));
    }

    IEnumerator SwitchBGM_Coro(AudioClip clip){
        // 如果正在播放这个BGM，那么跳过
        if(bgm.clip == clip) {
            Debug.Log("待切换的BGM已经在播放，跳过");
            yield break;
        }

        const float FADE_TIME = 0.5f;

        float start_time = Time.time;
        float initial_vol = bgm.isPlaying ? bgm.volume : 0;
        float progress = 0;

        // 如果已经有BGM在播放，那么淡出
        if(bgm.isPlaying){
            Debug.Log("开始淡出旧的BGM");
            while(progress < 1){
                progress = (Time.time - start_time) / FADE_TIME;
                bgm.volume = Mathf.Lerp(initial_vol, 0, progress);
                yield return new WaitForEndOfFrame();
            }
            bgm.Stop();
        }

        // 淡入新的BGM
        bgm.clip = clip;
        if(clip != null) bgm.Play();
       
        start_time = Time.time;
        initial_vol = bgm.volume;
        progress = 0;

        while(progress < 1){
            Debug.Log("开始淡入新的BGM");
            progress = (Time.time - start_time) / FADE_TIME;
            bgm.volume = Mathf.Lerp(initial_vol, 1, progress);
            yield return new WaitForEndOfFrame();
        }

        switch_bgm_coro = null;
    }
}