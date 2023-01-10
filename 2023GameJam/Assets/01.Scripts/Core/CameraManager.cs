using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoSingleton<CameraManager>
{   
    [SerializeField] private CinemachineVirtualCamera _mainCam;
    [SerializeField] private CinemachineVirtualCamera _playerCam;

    public void PlayerCamAssign(){
        _playerCam.Follow = GameObject.Find("Player(Clone)").transform;
    }

    public void PlayerCamActive(int firstPriority = 15, int secondPriority = 10){
        _mainCam.Priority = secondPriority;
        _playerCam.Priority = firstPriority;
    }

    public void MainCamActive(int firstPriority = 15, int secondPriority = 10){
        _mainCam.Priority = firstPriority;
        _playerCam.Priority = secondPriority;
    }
}
