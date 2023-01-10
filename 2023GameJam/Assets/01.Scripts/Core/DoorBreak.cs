using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBreak : MonoBehaviour
{
    public void BreakDoor()
    {
        Destroy(transform.GetChild(3).gameObject);
    }
}
