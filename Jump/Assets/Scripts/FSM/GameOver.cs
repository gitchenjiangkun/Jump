using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : IPlayerInput {
    
    public GameOver(IPlayer player)
    {
        LoadScene();
    }

    public void IUpdate()
    {
    }

    public void PlayerInput()
    {
    }
    /// <summary>
    /// 游戏结束加载场景
    /// </summary>
    public void LoadScene()  
    {
        SceneManager.LoadScene("Game");
    }

}
