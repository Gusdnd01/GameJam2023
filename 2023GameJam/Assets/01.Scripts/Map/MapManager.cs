using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    [SerializeField] private GameObject timer;


    [Space]
    public float nowTimer;
    public bool IsPlayerHere;

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
            nowTimer = 10 + ((stage % 100 / 10) * 5);
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
        timerTxt = timer.GetComponent<TextMeshProUGUI>();
    }

    TextMeshProUGUI timerTxt;

    public bool isMap;

    private void Update()
    {
        if (GameManager.Instance.isStart && isMap)
        {
            if (nowTimer > 0)
            {
                timer.SetActive(true);
                timerTxt.text = $"{(int)nowTimer+1}초간 도망치세요!";
                nowTimer -= TimeManager.DeltaTime;
            }
            else
            {
                enemySpawner.EnemyDespawn();
                // if (SpawnRoom.Count < 1)
                // {
                //     mapSpawn.SpawnNextMap();
                // }
                if (SpawnRoom.Count >= 1 && IsPlayerHere)
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
                timer.SetActive(false);
            }
        }
        else
        {
            return;
        }
    }

    //&& SpawnRoom[0].transform.childCount > 4
    private void DestroyRoom()
    {
        GameObject MapDoor;

        if (SpawnRoom.Count > 1)
        {
            MagicPoof[0].transform.position = SpawnRoom[0].transform.position;
            MagicPoof[0].Play();
            SoundManager.Instance.SFXPlay(0);
            Destroy(SpawnRoom[0]);
            SpawnRoom.RemoveAt(0);
            MapDoor = SpawnRoom[0].transform.GetChild(3).gameObject;
            MapDoor.SetActive(false);
        }
        else if (SpawnRoom.Count == 2)
        {
            MagicPoof[0].transform.position = SpawnRoom[0].transform.position;
            MagicPoof[0].Play();
            SoundManager.Instance.SFXPlay(0);
            MapDoor = SpawnRoom[0].transform.GetChild(3).gameObject;
            MapDoor.SetActive(false);
            Destroy(GameObject.Find("FirstMap"));
        }
        else
        {
            MapDoor = SpawnRoom[0].transform.GetChild(3).gameObject;
            SoundManager.Instance.SFXPlay(0);
            MapDoor.SetActive(false);
            Destroy(GameObject.Find("FirstMap"));
        }
    }
}
