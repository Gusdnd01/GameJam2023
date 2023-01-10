using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    public static GameManager Instance;
    public Animator[] anims;

    Button startButton;
    private void Awake()
    {

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

    [SerializeField] GameObject player; 
    [SerializeField] GameObject spawnParticle; 

    [SerializeField] RectTransform joyStick;

    void GameStart(){
        joyStick.DOAnchorPosY(-610, .5f,true);

        Destroy(GameObject.Find("PlayerAnim"));

        GameObject obj = Instantiate(player,new Vector3(0, -3.5f, 0), Quaternion.identity);
        GameObject instantiateParticle = Instantiate(spawnParticle, obj.transform.position, Quaternion.identity);
        instantiateParticle.GetComponent<ParticleSystem>().Play();
        Destroy(instantiateParticle, 3f);

        _playerTrm = GameObject.Find("Player(Clone)").transform;
        foreach(Animator animator in anims){
            animator.SetTrigger("Start");
        }
    }
}
