using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoMgr
{
    public static GameObject Player { get; internal set; }
    public static GameObject TargetBox { get; internal set; }
    public static GameObject CurrentBox { get; internal set; }
    public static GameObject CommonParticle { get; internal set; }
    public static GameObject CoreParticle { get; internal set; }
    public static ParticleSystem XuLiParticle { get; internal set; }

    public static void Init()
    {
        Player = Resources.Load("Player") as GameObject;
        CoreParticle = Resources.Load("CoreParticle") as GameObject;
        CommonParticle = Resources.Load("CommonParticle") as GameObject;
    }
}
