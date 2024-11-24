using UnityEngine;
using UnityEngine.UI;
public class menuUI : MonoBehaviour
{
    public static menuUI obj;
    public Button[] buttons = new Button[2];
    public Sprite background ;
    public void drawMenu()
    {
        while (GameManager.Manager.GameState)
        {
            drawButtons();
        }
    }

    void drawButtons()
    {
        for (int i = 0; i < 2; i++)
        {
            buttons[i].GetComponent<RectTransform>().position = new Vector2(GameManager.Manager.tempwidth += 10, GameManager.Manager.height * 0.50f);
            buttons[i].GetComponent<RectTransform>().sizeDelta = new Vector2(GameManager.Manager.width * 0.50f,GameManager.Manager.height * 0.50f);
        }
    }

    void Awake()
    {
        obj = this;
    }
}
