using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class GameManager : MonoBehaviour
{
    private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    public static GameManager Instance;
    Button startButton;
    private void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;

        if(Instance != null)
        {
            Debug.LogError("Multiple GameManger is running");
        }
        Instance = this;

        try{
            startButton = GameObject.Find("StartButton").GetComponent<Button>();

            startButton.onClick.AddListener(()=>{
                GameStart();
            });
        }
        catch(NullReferenceException){
            return;
        }
    }

    void GameStart(){
        SceneManager.LoadScene("HyunMap");
    }
}
