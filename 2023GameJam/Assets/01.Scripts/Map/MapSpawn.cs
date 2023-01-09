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


    public bool HitDoor = false;


    // public Vector3 DoorPos;
    // public Vector3 DoorSize;
    // public Transform Pos;

    // [SerializeField] private LayerMask isLayer;


    void Start()
    {
        mapList = FindObjectOfType<MapList>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNextMap();
        }
        // RaycastHit2D hit =
        // Physics2D.BoxCast(transform.position, DoorSize, 0, DoorPos, 5);

        // Gizmos.color = Color.red;
        // Debug.DrawRay(transform.position, Vector3.left * hit.distance);
        // Debug.dra
        // RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, isLayer);
        // if (ray.collider != null)
        // {


        //     if (ray.collider.CompareTag("enemy"))
        //     {
        //         Destroy(gameObject);
        //     }


        //}
        // HitDoor = Physics2D.OverlapBox(Pos.position, DoorSize, isLayer);
    }

    int RandomMap;
    private void SpawnNextMap()
    {
        switch (need)
        {
            case NeedDoorPos.Top:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedTob.Count);
                Instantiate(mapList.NeedTob[RandomMap], transform.position, Quaternion.identity);
                break;
            case NeedDoorPos.Bottom:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedBoT.Count);
                Instantiate(mapList.NeedBoT[RandomMap], transform.position, Quaternion.identity);
                break;
            case NeedDoorPos.Left:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedL.Count);
                Instantiate(mapList.NeedL[RandomMap], transform.position, Quaternion.identity);
                break;
            case NeedDoorPos.Right:
                RandomMap = UnityEngine.Random.Range(0, mapList.NeedR.Count);
                Instantiate(mapList.NeedR[RandomMap], transform.position, Quaternion.identity);
                break;
        }


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

        }
    }
}
