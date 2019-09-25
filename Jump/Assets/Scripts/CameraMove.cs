using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    /// <summary>
    /// 相机是否移动
    /// </summary>
    public static bool isCamMove;
    /// <summary>
    /// 角色与相机X轴偏移
    /// </summary>
    private float offsetx;
    /// <summary>
    /// 角色与相机Z轴偏移
    /// </summary>
    private float offsetz;  

    // Use this for initialization
    void Start () {
        offsetx = transform.position.x - transform.position.x - 2;
        offsetz = transform.position.z - transform.position.z - 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (isCamMove)
        {
            float tempx = Mathf.Lerp(transform.position.x, (GoMgr.CurrentBox.transform.position.x + GoMgr.TargetBox.transform.position.x) / 2 + 0.5f - offsetx, 0.2f);
            float tempz = Mathf.Lerp(transform.position.z, (GoMgr.CurrentBox.transform.position.z + GoMgr.TargetBox.transform.position.z) / 2 + 0.5f - offsetz, 0.2f);
            transform.position = new Vector3(tempx, transform.position.y, tempz);
        }
    }
}
