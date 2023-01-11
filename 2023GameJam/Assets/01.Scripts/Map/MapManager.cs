using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapManager : MonoBehaviour
{

    [Header("Rooms")]
    public List<GameObject> NeedTob;
    public List<GameObject> NeedBoT;
    public List<GameObject> NeedR;
    public List<GameObject> NeedL;


    public List<GameObject> SpawnRoom;
    public List<GameObject> Decorations;
    public List<ParticleSystem> MagicPoof;

    [Space]
    public float nowTimer;

    public GameObject EnemySpawner;
    private EnemySpawner enemySpawner;
    private MapSpawn mapSpawn;
    int stage;

    public int Stage
    {
        get => stage;
        set
        {
            Score += ((Stage * enemySpawner.EnemyList.Count) + 5);
            nowTimer = 5 + ((stage % 100 / 10) * 5);
            stage = value;
        }
    }

    int score;
    public int Score { get; set; }


    private void Start()
    {
        //stage = 0;
        enemySpawner = FindObjectOfType<EnemySpawner>();
        mapSpawn = GetComponent<MapSpawn>();
        //mapSpawn.SpawnNextMap();
    }

    private void Update()
    {
        if (nowTimer > 0)
        {
            nowTimer -= Time.deltaTime;
        }
        else
        {
            if (SpawnRoom.Count < 1)
            {
                mapSpawn.SpawnNextMap();
            }
            else if (SpawnRoom.Count >= 1)
            {
                DestroyRoom();
                SpawnRoom[0].GetComponentInChildren<MapSpawn>().SpawnNextMap();
            }
            // else
            // {
            //     DestroyRoom();
            //     // foreach (GameObject obj in SpawnRoom)
            //     // {
            //     //     obj.GetComponentInChildren<MapSpawn>().SpawnNextMap();
            //     // }
            //     SpawnRoom[0].GetComponentInChildren<MapSpawn>().SpawnNextMap();
            //     //return;
            // }
        }
    }

    private void DestroyRoom()
    {
        if (SpawnRoom.Count > 1)
        {
            MagicPoof[0].transform.position = SpawnRoom[0].transform.position;
            MagicPoof[0].Play();

            Destroy(SpawnRoom[0]);
            SpawnRoom.RemoveAt(0);
            Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
        }
        else if (SpawnRoom.Count == 2 && SpawnRoom[0].transform.childCount > 4)
        {
            MagicPoof[0].transform.position = SpawnRoom[0].transform.position;
            MagicPoof[0].Play();

            Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
            Destroy(GameObject.Find("FirstMap"));
        }
        else
        {
            Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
            Destroy(GameObject.Find("FirstMap"));
        }
    }
}
