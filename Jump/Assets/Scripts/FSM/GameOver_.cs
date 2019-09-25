using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver_ : IPlayerInput
{

    private IPlayer playerInput;
    private GameObject player;

    /// <summary>
    /// 是否旋转
    /// </summary>
    private bool isRote;
    /// <summary>
    /// 旋转角度
    /// </summary>
    private int xorz;
    /// <summary>
    /// 多长时间加载死亡
    /// </summary>
    private float time;

    public GameOver_(IPlayer player, bool isRote, int xOrz)
    {
        this.playerInput = player;
        this.player = GoMgr.Player;
        this.isRote = isRote;
        this.xorz = xOrz;
    }

    public void IUpdate()
    {
        if (isRote)
        {
            Quaternion target;
            if (xorz == 1)
            {
                target = Quaternion.Euler(0, 0, -90);
            }else if(xorz == 2)
            {
                target = Quaternion.Euler(0, 0, 90);
            }
            else if(xorz == 3)
            {
                target = Quaternion.Euler(90, 0, 0);
            }
            else if(xorz == 4)
            {
                target = Quaternion.Euler(-90, 0, 0);
            }
            else
            {
                target = Quaternion.Euler(0, 0, 0);
            }
            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, target, 2.0f);
        }
        time += Time.deltaTime;
        if(time > 3f)
        {
            playerInput.SetPlayerState(new GameOver(GameData.PlayerInput));
        }
    }

    public void PlayerInput()
    {
    }

}
