using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxData : MonoBehaviour {
    
    private BoxCollider boxBC;

    private void Start()
    {
        boxBC = GetComponent<BoxCollider>();
    }

    /// <summary> 实例化箱子 </summary>
    public static void InsBox()  
    {
        int tempnum = UnityEngine.Random.Range(1, 3);
        float rx = 0;
        float rz = 0;

        if (tempnum == 1)
        {
            rx = UnityEngine.Random.Range(-3.0f, -2f);
        }
        else
        {
            rz = UnityEngine.Random.Range(-3.0f, -2f);
        }
        int index = UnityEngine.Random.Range(0, 15);

        float tempX = GoMgr.CurrentBox.transform.position.x + rx;
        float tempZ = GoMgr.CurrentBox.transform.position.z + rz;
        
        GameObject box = Instantiate(GameData.Boxs[index], new Vector3(tempX, 3, tempZ), new Quaternion());
        GoMgr.TargetBox = box;
        GameData.BoxsList.Add(box);

        //ChangeBoxByScore(box);
        box.GetComponent<Rigidbody>().isKinematic = false;
        box.GetComponent<Rigidbody>().constraints = ~RigidbodyConstraints.FreezePositionY;
        box.GetComponent<Rigidbody>().velocity = Vector3.down * 7f;

    }
    /// <summary> 中心点判断 </summary>
    public void CorePoint(GameObject box) 
    {
        float Distance = Vector3.Distance(new Vector3(GoMgr.Player.transform.position.x, 0, GoMgr.Player.transform.position.z), box.GetComponent<Transform>().position);

        if (Distance < 0.1f)
        {
            GameData.CoreParticleCount++;
            if (GameData.CoreParticleCount > GameData.CoreParticleList.Count)
            {
                GameObject obj = Instantiate(GoMgr.CoreParticle);
                obj.SetActive(false);
                obj.GetComponent<Transform>().SetParent(GameObject.Find("Eff").GetComponent<Transform>());
                obj.GetComponent<Transform>().localPosition = Vector3.zero;
                GameData.CoreParticleList.Add(obj);
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(AudioManager.GetInstance.Core);

            StartCoroutine(ZhongxinRecursion(GameData.CoreParticleCount));
        }
        else
        {
            GoMgr.CommonParticle.SetActive(true);
            GameData.CoreParticleCount = 0;

            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(AudioManager.GetInstance.Common);
        }
    }
    /// <summary>
    /// 中心粒子
    /// </summary>
    IEnumerator ZhongxinRecursion(int nums)  
    {
        yield return new WaitForSeconds(0.05f);
        if (nums > 0)
        {
            GameData.CoreParticleList[nums - 1].SetActive(true);
            StartCoroutine(SetFalse(GameData.CoreParticleList[nums - 1]));
            StartCoroutine(ZhongxinRecursion(nums - 1));
        }
    }
    /// <summary>
    /// 中心粒子
    /// </summary>
    IEnumerator SetFalse(GameObject obj)  
    {
        yield return new WaitForSeconds(0.6f);
        obj.SetActive(false);
    }
    /// <summary>
    /// box随分数变小
    /// </summary>
    /// <param name="box"></param>
    public static void ChangeBoxByScore(GameObject box)
    {
        switch ((int)(GameData.Score / GameData.BoxSmall))
        {
            case 1:
                box.transform.localScale = new Vector3(0.8f, 0, 0.8f);
                break;
            case 2:
                box.transform.localScale = new Vector3(0.6f, 0, 0.6f);
                break;
            case 3:
                box.transform.localScale = new Vector3(0.4f, 0, 0.4f);
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Floor"))
        {
            boxBC.material = null;
        }
    }
    /// <summary>
    /// 销毁box
    /// </summary>
    public static void BoxDelete()
    {
        if(GameData.BoxsList.Count > 5)
        {
            Destroy(GameData.BoxsList[0]);
            GameData.BoxsList.Remove(GameData.BoxsList[0]);
        }
    }
}
