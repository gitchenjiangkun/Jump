using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IPlayerInput {

    private IPlayer playerInput;
    private GameObject player;

    public IdleState(IPlayer player)
    {
        GameData.PlayerInput = player;
        GameData.Dynamics = 0;

        this.player = GoMgr.Player;
        this.player.transform.rotation = new Quaternion();

        BoxState.IsBoxLargen = false;
        Time.timeScale = 1f;

        GoMgr.XuLiParticle.gameObject.SetActive(false);
        this.player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.player.GetComponent<AudioSource>().Stop();
        
    }

    public void IUpdate()
    {

    }

    public void PlayerInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameData.PlayerInput.SetPlayerState(new XuLiState(GameData.PlayerInput));
        }
    }

}
