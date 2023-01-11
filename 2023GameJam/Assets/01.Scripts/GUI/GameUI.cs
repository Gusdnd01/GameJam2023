using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameUI : MonoBehaviour
{
    [Header("reference")]
    [SerializeField] private Image GameOverOBJ;
    [SerializeField] private TextMeshProUGUI ScoreTXT;
    [SerializeField] private TextMeshProUGUI IngameSocreTXT;

    public static GameUI Instance;

    private MapManager mapManager;

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

    private void Awake() {
        Instance = this;
        
    }

    private void Start()
    {
        GameoverRect = GameOverOBJ.GetComponent<RectTransform>();
        mapManager = FindObjectOfType<MapManager>();

        mapManager.Score = 0;
    }

    private void FixedUpdate()
    {
        IngameSocreTXT.text = "score : " + mapManager.Score.ToString();
        ScoreTXT.text = "점수: " + string.Format("{0:00000}", mapManager.Score);
    }

    public void MoveDown()
    {
        GameoverRect.DOAnchorPosY(0, 1).SetEase(Ease.InExpo).SetEase(Ease.OutBounce);
        GameManager.Instance.joyStick.DOAnchorPosY(-1279,1);
        //GameoverRect.DOAnchorPosY(1939.68f, 1.5f).SetEase(Ease.InExpo).SetEase(Ease.OutBounce);
    }

    public void Quit(){
        Application.Quit();
    }


    public void ReStart()
    {
        TimeManager.TimeScale = 1;
        SoundManager.Instance.SFXPlay(2);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
