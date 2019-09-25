using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLiState : IPlayerInput {

    private GameObject player;

    private float inputTime;

    public XuLiState(IPlayer player)
    {
        this.player = GoMgr.Player;
        GoMgr.XuLiParticle.gameObject.SetActive(true);
        this.player.GetComponent<AudioSource>().PlayOneShot(AudioManager.GetInstance.StarXuli);
    }

    public void IUpdate()
    {
        XuLipar();
        BoxState.BoxSmallFun();
        GameData.PlayerInput.PlayerSmall();
        LoopXuli();
    }

    public void PlayerInput()
    {
        if (Input.GetMouseButton(0))
        {
            inputTime += Time.deltaTime;
            if (GameData.Dynamics < 10)
            {
                GameData.Dynamics += Time.deltaTime * 3;
            }
        }
        if (Input.GetMouseButtonUp(0) || inputTime > 2f)
        {
            inputTime = 0f;
            GameData.PlayerInput.SetPlayerState(new JumpState(GameData.PlayerInput));
        }
        
    }
    /// <summary>
    /// 蓄力粒子特效
    /// </summary>
    /// <param name="mian"></param>
    void XuLipar()  
    {
        int count = GoMgr.XuLiParticle.GetParticles(GameData.XuLiParticleArray);
        for (int i = 0; i < count; i++)
        {
            GameData.XuLiParticleArray[i].position = Vector3.Lerp(GameData.XuLiParticleArray[i].position, player.transform.position, 0.1f);
        }
        GoMgr.XuLiParticle.SetParticles(GameData.XuLiParticleArray, count);
    }
    /// <summary>
    /// 蓄力音效
    /// </summary>
    void LoopXuli()
    {
        if (!player.GetComponent<AudioSource>().isPlaying)
        {
            player.GetComponent<AudioSource>().clip = AudioManager.GetInstance.XuLi;
            //player.GetComponent<AudioSource>().Play();
            player.GetComponent<AudioSource>().loop = true;
        }
    }
}
