using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameData
{
    public static IPlayer PlayerInput { get; set; }

    public static int CoreParticleCount { get; set; }
    public static int ChangeCount { get; set; }

    public static float Dynamics { get; set; }
    public static float Score { get; set; }
    public static float BoxSmall { get; set; }

    public static GameObject[] Boxs { get; set; }
    public static ParticleSystem.Particle[] XuLiParticleArray { get; set; }
    public static List<GameObject> BoxsList { get; set; }
    public static List<GameObject> CoreParticleList { get; set; }

    static GameData()
    {
        BoxSmall = 10;

        BoxsList = new List<GameObject>();
        CoreParticleList = new List<GameObject>();

        Boxs = Resources.LoadAll<GameObject>("Box") as GameObject[];
    }

    public static void Init()
    {
        PlayerInput = new IPlayer();
        CoreParticleCount = 0;
        ChangeCount = 0;
        Dynamics = 0;
        Score = 0;
        BoxsList = new List<GameObject>();
        CoreParticleList = new List<GameObject>();
    }
}
