using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "audio_res", menuName = "ScriptableObject/声音数据", order = 0)]
public class AudioRes : ScriptableObject
{
    // 背景音乐
    public AudioClip bgm_主界面;
    public AudioClip bgm_咖啡馆;
    public AudioClip bgm_宇宙;
    public AudioClip bgm_野外丛林;

    public AudioClip bgm_漫画1;

    public AudioClip bgm_漫画2;

    public AudioClip bgm_漫画3;
    // 音效
    public List<AudioClip> main_effects = new List<AudioClip>();
    public List<AudioClip> effects = new List<AudioClip>();
}
