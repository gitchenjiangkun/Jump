using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class JumpState : IPlayerInput {
    
    public JumpState(IPlayer player)
    {
        CameraMove.isCamMove = false;

        GoMgr.CurrentBox.GetComponent<BoxCollider>().enabled = false;

        GoMgr.CommonParticle.SetActive(false);

        GoMgr.XuLiParticle.gameObject.SetActive(false);

        GoMgr.Player.GetComponent<AudioSource>().Stop();
        
        JumpFun(GoMgr.Player, GameData.Dynamics);
    }

    public void IUpdate()
    {
        JumpRote(GoMgr.Player);
        GameData.PlayerInput.PlayerLargen();
        BoxState.BoxLargen();
        OpenBoxCollider();
    }

    public void PlayerInput()
    {
    }
    /// <summary>
    /// 跳跃
    /// </summary>
    /// <param name="player"></param>
    /// <param name="time"></param>
    private void JumpFun(GameObject player, float time)  
    {

        if (player.transform.position.x - GoMgr.TargetBox.transform.position.x > 1)
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(-1 * time, 6f, GoMgr.TargetBox.transform.position.z - player.transform.position.z);
        }
        else
        {
            player.GetComponent<Rigidbody>().velocity = new Vector3(GoMgr.TargetBox.transform.position.x - player.transform.position.x, 6f, -1 * time);
            player.transform.Rotate(0, -90, 0, Space.Self);
        }

    }

    //旋转
    private void JumpRote(GameObject player)  
    {
        Time.timeScale = 3f;
        player.transform.Rotate(0, 0, 5.7f, Space.Self);
    }

    //开启盒子碰撞
    private void OpenBoxCollider()  
    {
        if (!GoMgr.CurrentBox.GetComponent<BoxCollider>().enabled)
        {
            if (GoMgr.Player.transform.position.y > 1)
            {
                GoMgr.CurrentBox.GetComponent<BoxCollider>().enabled = true;
            }
        }
        
    }

    //设置死亡
    public static void SetIdleState(bool IsCollider)
    {
        GameData.PlayerInput.SetPlayerState(new IdleState(GameData.PlayerInput));
    }
}
