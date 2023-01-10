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
    [Space]
    public List<GameObject> Decorations;
    [Space]
    public List<ParticleSystem> MagicPoof;
    public float nowTimer;
    private MapSpawn mapSpawn;
    int stage;

    public int Stage
    {
        get => stage;
        set
        {
            nowTimer = 30 + ((stage % 100 / 10) * 5);
            stage = value;
        }
    }

    private void Start()
    {
        stage = 0;
        mapSpawn = GetComponent<MapSpawn>();
        mapSpawn.SpawnNextMap();
    }

    private void Update()
    {
        if (nowTimer > 0)
        {
            nowTimer -= Time.deltaTime;
        }
        else
        {
            if (SpawnRoom.Count > 2)
            {
                SpawnRoom[1].GetComponent<MapSpawn>().SpawnNextMap();
            }
            else
            {
                SpawnRoom[0].GetComponent<MapSpawn>().SpawnNextMap();
            }
        }
    }

    private void DestroyRoom()
    {
        if (SpawnRoom.Count > 2)
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
    }
}
