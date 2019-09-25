using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IPlayer{
    
    public IPlayerInput State;

    public IPlayer()
    {
        State = new InitState(this);
    }

    public void SetPlayerState(IPlayerInput newState)
    {
        State = newState;
    }

    public void Update()
    {
        State.PlayerInput();
    }

    public void FixedUpdate()
    {
        State.IUpdate();
    }

    //角色变小
    public void PlayerSmall() 
    {
        if(GoMgr.Player.transform.localScale.y > 0.5f)
        {
            GoMgr.Player.transform.localScale -= new Vector3(-Time.deltaTime, Time.deltaTime, -Time.deltaTime);
        }
    }

    //角色变大
    public void PlayerLargen() 
    {
        if (GoMgr.Player.transform.localScale.y < 1f)
        {
            GoMgr.Player.transform.localScale += new Vector3(-Time.deltaTime, Time.deltaTime, -Time.deltaTime);
        }
    }
    
    
}
