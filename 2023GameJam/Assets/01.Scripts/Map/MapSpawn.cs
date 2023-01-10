using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSpawn : MonoBehaviour
{

    public enum NeedDoorPos
    {
        Top,
        Bottom,
        Left,
        Right
    };

    [SerializeField] private NeedDoorPos need;
    private MapList mapList;
    public bool Spawned = false;



    private void Awake()
    {
        mapList = FindObjectOfType<MapList>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Spawned)
        {
            SpawnNextMap();
        }
    }

    int RandomMap;
    public void SpawnNextMap()
    {
        //mapList.SpawnRoom[0].GetComponent<DoorBreak>().

        switch (need)
        {
            case NeedDoorPos.Top:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedTob.Count);
                GameObject roomT = Instantiate(mapList.NeedTob[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomT);
                break;
            case NeedDoorPos.Bottom:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedBoT.Count);
                GameObject roomB = Instantiate(mapList.NeedBoT[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomB);
                break;
            case NeedDoorPos.Left:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedL.Count);
                GameObject roomL = Instantiate(mapList.NeedL[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomL);
                break;
            case NeedDoorPos.Right:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedR.Count);
                GameObject roomR = Instantiate(mapList.NeedR[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomR);
                break;
        }
        Spawned = true;
    }

}
