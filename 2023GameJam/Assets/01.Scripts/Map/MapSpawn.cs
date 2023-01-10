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
        GameObject roomOBJ;
        GameObject deco;

        switch (need)
        {
            case NeedDoorPos.Top:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedTob.Count);
                roomOBJ = Instantiate(mapList.NeedTob[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomOBJ);
                RandomMap = UnityEngine.Random.Range(0, mapList.Decorations.Count);
                deco = Instantiate(mapList.Decorations[RandomMap], transform.position, Quaternion.identity);
                deco.transform.SetParent(roomOBJ.transform);
                break;
            case NeedDoorPos.Bottom:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedBoT.Count);
                roomOBJ = Instantiate(mapList.NeedBoT[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomOBJ);
                RandomMap = UnityEngine.Random.Range(0, mapList.Decorations.Count);
                deco = Instantiate(mapList.Decorations[RandomMap], transform.position, Quaternion.identity);
                deco.transform.SetParent(roomOBJ.transform);
                break;
            case NeedDoorPos.Left:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedL.Count);
                roomOBJ = Instantiate(mapList.NeedL[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomOBJ);
                RandomMap = UnityEngine.Random.Range(0, mapList.Decorations.Count);
                deco = Instantiate(mapList.Decorations[RandomMap], transform.position, Quaternion.identity);
                deco.transform.SetParent(roomOBJ.transform);
                break;
            case NeedDoorPos.Right:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedR.Count);
                roomOBJ = Instantiate(mapList.NeedR[RandomMap], transform.position, Quaternion.identity);
                mapList.SpawnRoom.Add(roomOBJ);
                RandomMap = UnityEngine.Random.Range(0, mapList.Decorations.Count);
                deco = Instantiate(mapList.Decorations[RandomMap], transform.position, Quaternion.identity);
                deco.transform.SetParent(roomOBJ.transform);
                break;
        }
        Spawned = true;
    }

}
