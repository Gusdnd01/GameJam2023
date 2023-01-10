using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private GameObject GameOverOBJ;
    [SerializeField] private TextMeshProUGUI ScoreTXT;

    [Space]
    [SerializeField] private float MoveSpeed = 5;
    public bool MoveDown { get; set; }

    private void Start()
    {
        MoveDown = true;
    }

    private void Update()
    {
        if (MoveDown)
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-493.8377f, -67.19513f, -267.376f), MoveSpeed * Time.deltaTime);
            GameOverOBJ.transform.DOMove(new Vector3(-493.8377f, -67.19513f, -267.376f), 3).SetEase(Ease.Linear).SetEase(Ease.OutElastic);
        }
        else
        {
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(-493.8377f, 1873, -267.376f), MoveSpeed * Time.deltaTime);
            GameOverOBJ.transform.DOMove(new Vector3(-493.8377f, 1873, -267.376f), 3).SetEase(Ease.Linear).SetEase(Ease.OutElastic);
        }
    }


    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
