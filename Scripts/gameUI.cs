using UnityEngine;
using UnityEngine.UI;
public class gameUI : MonoBehaviour
{
    public static gameUI obj;

    public GameObject headerbox, timerbox, questionbox, popupbox;
    public Button[] buttons = new Button[4];
    Vector2 position, size;
    float temppos = 0f;


    public void drawGameUI()
    {
        drawHeader(); //0.06
        drawTimer(); // 0.02
        drawQuestion(); //0.10
        drawAnswers(); //0.06-8
    }

    void drawHeader()
    {
        headerbox.GetComponent<RectTransform>().localPosition = new Vector2( 0, GameManager.Manager.height*0.47f);
        headerbox.GetComponent<RectTransform>().sizeDelta = new Vector2( GameManager.Manager.width, GameManager.Manager.height * 0.06f);
        headerbox.GetComponentInChildren<Text>().fontSize = Mathf.RoundToInt(GameManager.Manager.height * 0.03f);
        headerbox.GetComponentInChildren<Text>().text = levelData.obj.levelNames[levelData.obj.currentLevel];
    }

    void  drawTimer()
    {
        timerbox.GetComponent<RectTransform>().localPosition = new Vector2( GameManager.Manager.width * -0.50f, GameManager.Manager.height * 0.43f);
        timerbox.GetComponent<RectTransform>().sizeDelta = new Vector2( GameManager.Manager.width * 2, GameManager.Manager.height * 0.02f);
    }

    void drawQuestion()
    {
        questionbox.GetComponent<RectTransform>().localPosition = new Vector2( 0, GameManager.Manager.height * 0.16f);
        questionbox.GetComponent<RectTransform>().sizeDelta = new Vector2( GameManager.Manager.width * 0.75f, GameManager.Manager.height * 0.46f);
        questionbox.GetComponentInChildren<Text>().text = levelData.obj.levels[levelData.obj.currentLevel][levelData.obj.questions[levelData.obj.currentQuestion],0];
        questionbox.GetComponentInChildren<Text>().fontSize = Mathf.RoundToInt(GameManager.Manager.height * 0.05f);
    }

    void drawAnswers()
    {
        for (int i = 0; i < levelData.obj.answers.Length; i++)
        {
            buttons[i].GetComponent<RectTransform>().localPosition = new Vector2( 0, GameManager.Manager.height * -(temppos += 0.10f));
            buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2( GameManager.Manager.width * 0.50f, GameManager.Manager.height * 0.08f);
            buttons[i].GetComponentInChildren<Text>().text = levelData.obj.levels[levelData.obj.currentLevel][levelData.obj.answers[i],1];
            buttons[i].GetComponentInChildren<Text>().fontSize = Mathf.RoundToInt(GameManager.Manager.height * 0.03f);
        }
        assignButtons();
        temppos = 0f;
    }

    public void drawTimerCountdown()
    {
        timerbox.GetComponent<RectTransform>().sizeDelta = new Vector2(GameManager.Manager.tempwidth -= GameManager.Manager.width*2 / GameManager.Manager.countdown, GameManager.Manager.height * 0.02f);
    }

    void assignButtons()
    {
        for (int i = 0; i < levelData.obj.answers.Length; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
            if (i == levelData.obj.cell)
                buttons[i].onClick.AddListener(QA.rightAnswer);
            else
                buttons[i].onClick.AddListener(GameManager.Manager.gameStop);
        }   
    }

    public void drawPopUp()
    {
        popupbox.GetComponent<RectTransform>().localPosition = new Vector2( 0, 0);
        popupbox.GetComponent<RectTransform>().sizeDelta = new Vector2( GameManager.Manager.width * 0.90f, GameManager.Manager.height * 0.90f);
    }
    void Awake()
    {
        obj = this;
    }
}