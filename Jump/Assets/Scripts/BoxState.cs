using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxState {
    
    /// <summary>
    /// boxY轴变形
    /// </summary>
    private static Vector3 boxYVelocity;
    /// <summary>
    /// 是否变大
    /// </summary>
    public static bool IsBoxLargen;
    
    /// <summary>
    /// 变小
    /// </summary>
    public static void BoxSmallFun()  
    {
        if (GoMgr.CurrentBox.transform.localScale.y > 0.5f)
        {
            GoMgr.CurrentBox.transform.localScale -= new Vector3(0, Time.deltaTime / 1.5f, 0);
        }
    }
    /// <summary>
    /// 变大
    /// </summary>
    public static void BoxLargen()  
    {
        var f = (new Vector3(GoMgr.CurrentBox.transform.localScale.x, 1, GoMgr.CurrentBox.transform.localScale.z) - GoMgr.CurrentBox.transform.localScale) * 1.5f;
        boxYVelocity += f;
        boxYVelocity = Vector3.Lerp(boxYVelocity, Vector3.zero, 0.2f);
        GoMgr.CurrentBox.transform.localScale += boxYVelocity;
    }

    
}
