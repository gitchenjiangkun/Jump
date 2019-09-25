using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    /// <summary>
    /// 投币
    /// </summary>
    public AudioClip Coint { get; private set; }
    /// <summary>
    /// 普通加分
    /// </summary>
    public AudioClip Common { get; private set; }
    /// <summary>
    /// 中心加分
    /// </summary>
    public AudioClip Core { get; private set; }
    /// <summary>
    /// 死亡
    /// </summary>
    public AudioClip Die { get; private set; }
    /// <summary>
    /// 开始蓄力
    /// </summary>
    public AudioClip StarXuli { get; private set; }
    /// <summary>
    /// 蓄力中
    /// </summary>
    public AudioClip XuLi { get; private set; }

    public static AudioManager GetInstance
    {
        get; private set;
    }

    private void Awake()
    {
        GetInstance = this;

        Coint = Resources.Load("Music/coint") as AudioClip;
        Common = Resources.Load("Music/common") as AudioClip;
        Core = Resources.Load("Music/core") as AudioClip;
        Die = Resources.Load("Music/die") as AudioClip;
        StarXuli = Resources.Load("Music/startXuli") as AudioClip;
        XuLi = Resources.Load("Music/xuLi") as AudioClip;
    }
    
}
