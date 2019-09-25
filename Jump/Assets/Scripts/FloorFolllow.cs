using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorFolllow : MonoBehaviour {
    
    private void Update()
    {
        FloorColor();
    }
    /// <summary>
    /// 地面跟随
    /// </summary>
    public void FloorFollowFun()  
    {
        transform.position = new Vector3(GoMgr.Player.transform.position.x, 0, GoMgr.Player.transform.position.z);
    }
    /// <summary>
    /// 地面颜色
    /// </summary>
    private void FloorColor()
    {
        float r = Mathf.Cos(0.01f * Time.time) / 20 + 0.4f;
        float g = Mathf.Sin(0.01f * Time.time) / 5 + 0.5f;
        float b = Mathf.Cos(0.01f * Time.time) / 8 + 0.5f;
        GetComponent<Renderer>().material.color = new Color(r, g, b, b);
    }
}
