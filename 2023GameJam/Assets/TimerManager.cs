using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public ParticleSystem magic;

    private void OnEnable() {
        magic.Play();
    }

    private void OnDisable() {
        magic.Play();
    }
}
