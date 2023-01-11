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
    public Button pauseButton;
    private void Awake()
    {

        if (Instance != null)
        {
            Debug.LogError("Multiple GameManger is running");
        }
        Instance = this;

        try
        {
            startButton = GameObject.Find("StartButton").GetComponent<Button>();

            startButton.onClick.AddListener(() =>
            {
                GameStart();
            });
        }
        catch (NullReferenceException)
        {
            return;
        }
    }

    private void Start()
    {
        SoundManager.Instance.BGMPlay(0);
    }

    public Animator pausePanelAnim;
    public Animator settingPanelAnim;

    public void PausePanelActive()
    {
        pausePanelAnim.SetTrigger("Start");
        pauseButton.interactable = false;
        TimeManager.TimeScale = 0;
    }
    public void ResumeBtnOnClicked()
    {
        print("Up!!");
        TimeManager.TimeScale = 1;
        pausePanelAnim.SetTrigger("Up");
        pauseButton.interactable = true;
    }

    public void QuitBtnOnClicked()
    {
        print("QuitGame!!");
        Application.Quit();
    }

    public void SettingBtnOnClicked()
    {
        pausePanelAnim.SetTrigger("Up");
        //설정창 켜주기
        settingPanelAnim.SetTrigger("Start");
    }

    public void SettingPanelDisable()
    {
        Sequence seq = DOTween.Sequence();
        pausePanelAnim.SetTrigger("Start");
        settingPanelAnim.SetTrigger("Up");
        seq.AppendInterval(1f);
        seq.Append(settingPanelAnim.GetComponent<RectTransform>().DOAnchorPosX(-1000, 0));
        seq.AppendCallback(() =>
        {
            seq.Kill();
        });
    }

    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnParticle;

    [SerializeField] RectTransform joyStick;

    void GameStart()
    {
        SoundManager.Instance.BGMPlay(1);

        startButton.gameObject.SetActive(false);
        joyStick.DOAnchorPosY(-610, .5f, true);

        Destroy(GameObject.Find("PlayerAnim"));

        GameObject obj = Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.identity);
        CameraManager.Instance.PlayerCamAssign();

        GameObject instantiateParticle = Instantiate(spawnParticle, obj.transform.position, Quaternion.identity);
        instantiateParticle.GetComponent<ParticleSystem>().Play();
        CameraManager.Instance.PlayerCamActive(15, 10);
        Destroy(instantiateParticle, 3f);

        _playerTrm = GameObject.Find("Player(Clone)").transform;
        foreach (Animator animator in anims)
        {
            animator.SetTrigger("Start");
            if (animator.GetComponentInChildren<ParticleSystem>() != null)
            {
                animator.GetComponentInChildren<ParticleSystem>().Play();
            }
        }
    }
}

public static class TimeManager
{
    static float timeScale = 1;

    public static float TimeScale
    {
        get => timeScale;
        set => timeScale = value;
    }

    static float deltaTime;
    public static float DeltaTime { get { return Time.deltaTime * timeScale; } }
}