using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour {
    
    private void Awake()
    {
        GameData.Init();
        GoMgr.Init();
    }

    private void Start()
    {
        GoMgr.Player = Instantiate(GoMgr.Player, new Vector3(0, 1, 0), new Quaternion());
        GoMgr.XuLiParticle = GoMgr.Player.transform.Find("Eff/XuLiParticle").GetComponent<ParticleSystem>();
        GoMgr.CurrentBox = Instantiate(GameData.Boxs[0], Vector3.zero, new Quaternion());
        GoMgr.CommonParticle = GoMgr.Player.transform.Find("Eff/CommonParticle").gameObject;
        GameData.XuLiParticleArray = new ParticleSystem.Particle[GoMgr.XuLiParticle.main.maxParticles];
    }
    
}
