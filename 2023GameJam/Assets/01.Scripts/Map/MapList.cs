using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapList : MonoBehaviour
{

    public List<GameObject> NeedTob;
    public List<GameObject> NeedBoT;
    public List<GameObject> NeedR;
    public List<GameObject> NeedL;

    public List<GameObject> SpawnRoom;
    private int RoomCount;

    private void Start()
    {
        //Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
    }

    private void FixedUpdate()
    {


        if (SpawnRoom.Count > 2)
        {
            Destroy(SpawnRoom[0]);
            SpawnRoom.RemoveAt(0);
            Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
        }
        else if (SpawnRoom.Count == 2 && SpawnRoom[0].transform.childCount > 3)
        {
            Destroy(SpawnRoom[0].transform.GetChild(3).gameObject);
        }
    }
}