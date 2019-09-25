using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {
    
    void Start () {
        BoxData.InsBox();
        CameraMove.isCamMove = true;
    }
	
	void Update () {
        GameData.PlayerInput.Update();
    }

    private void FixedUpdate()
    {
        GameData.PlayerInput.FixedUpdate();
    }

    private void OnCollisionEnter(Collision collision)  //碰撞
    {
        if ((GameData.PlayerInput.State.ToString() == "JumpState" || GameData.PlayerInput.State.ToString() == "InitState") && GameData.PlayerInput.State.ToString() != "GameOver_")
        {
            JumpState.SetIdleState(collision.gameObject);
        }

        if (collision.gameObject.name == "Floor" && GoMgr.CurrentBox.name != "Floor")
        {
            StartCoroutine("PlayDieMusic");
            return;
        }

        if (DieTest(GoMgr.CurrentBox, collision) )
        {
            return;
        }

        if(GoMgr.CurrentBox == collision.gameObject)
        {
            return;
        }

        GoMgr.CurrentBox = collision.gameObject;

        if (GoMgr.CurrentBox != GoMgr.TargetBox && GoMgr.Player.transform.position.y < 0.6f)
        {
            return;
        }

        BoxData.InsBox();
        CameraMove.isCamMove = true;
        GoMgr.CurrentBox.GetComponent<BoxData>().CorePoint(GoMgr.CurrentBox);
        BoxData.BoxDelete();
        GameObject.FindGameObjectWithTag("Floor").GetComponent<FloorFolllow>().FloorFollowFun();
    }

    /// <summary>
    /// 是否碰到地面
    /// </summary>
    /// <param name="collision"></param>
    private void IsCollisionFloor(Collision collision)  
    {
        if(collision.gameObject.name == "Floor" && GoMgr.CurrentBox.name != "Floor")
        {
            StartCoroutine("PlayDieMusic");
        }
    }
    /// <summary>
    /// 射线检测
    /// </summary>
    /// <param name="box"></param>
    /// <param name="collision"></param>
    /// <returns></returns>
    private bool DieTest(GameObject box, Collision collision)
    {
        Ray ray = new Ray(new Vector3(transform.position.x, transform.position.y + 0.1f, transform.position.z), Vector3.down);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && GameData.PlayerInput.State.ToString() != "GameOver_")
        {
            if (hit.collider.gameObject.name == "Floor" && collision.gameObject.name != "Floor" && transform.position.y > 0.6f)
            {
                GetComponent<Rigidbody>().useGravity = false;
                StartCoroutine("WaitTimeUseGravity");
                if (GoMgr.CurrentBox.transform.position.z == GoMgr.TargetBox.transform.position.z && GameData.PlayerInput.State.ToString() != "GameOver_")
                {
                    if(transform .position.x > GoMgr.TargetBox.transform.position.x)
                    {
                        if (collision.gameObject.name == GoMgr.TargetBox.gameObject.name)
                        {
                            GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 1));
                        }
                        else
                        {
                            GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 2));
                        }
                    }
                    else
                    {
                        GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 2));
                    }
                }
                else
                {
                    if(transform.position.z > GoMgr.TargetBox.transform.position.z)
                    {
                        if (collision.gameObject.name == GoMgr.TargetBox.gameObject.name)
                        {
                            GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 3));
                        }
                        else
                        {
                            GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 4));
                        }
                    }
                    else
                    {
                        GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, true, 4));
                    }
                    
                }
                return true;
            }
        }
        return false;
    }
    /// <summary>
    /// 使用重力
    /// </summary>
    /// <returns></returns>
    IEnumerator WaitTimeUseGravity()
    {
        yield return new WaitForSeconds(0.5f);
        GetComponent<Rigidbody>().useGravity = true;
    }
    /// <summary>
    /// 播放死亡音效
    /// </summary>
    /// <returns></returns>
    IEnumerator PlayDieMusic()
    {
        GameData.PlayerInput.SetPlayerState(new GameOver_(GameData.PlayerInput, false, 0));
        GoMgr.Player.GetComponent<AudioSource>().PlayOneShot(AudioManager.GetInstance.Die);
        yield return new WaitForSeconds(1.5f);
        GameData.PlayerInput.SetPlayerState(new GameOver(GameData.PlayerInput));
    }
}
