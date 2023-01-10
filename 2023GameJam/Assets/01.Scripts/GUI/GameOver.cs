using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameOver : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private Image GameOverOBJ;
    [SerializeField] private TextMeshProUGUI ScoreTXT;

    public bool MoveDownbool
    {
        get
        {
            return MoveDownbool;
        }
        set
        {
            if (MoveDownbool)
            {
                MoveDown();
                return;
            }
        }
    }

    private RectTransform GameoverRect;


    private void Start()
    {
        GameoverRect = GameOverOBJ.GetComponent<RectTransform>();
    }

    private void Update()
    {


    }

    public void MoveDown()
    {
        GameoverRect.DOAnchorPosY(0, 1).SetEase(Ease.InExpo).SetEase(Ease.OutBounce);

        //GameoverRect.DOAnchorPosY(1939.68f, 1.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce);
    }


    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
