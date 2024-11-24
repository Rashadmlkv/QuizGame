using UnityEngine;
using System.Linq;
using System.Collections;
public class game : MonoBehaviour
{
    //Levele gore suallarin random indexi olan array yig
    //Her sual indexinde random cavab sirasi olan ve duz cavabda icinde olan array yig
    //
    IEnumerator gameLoop()
    {
        QA.createQuestions();
        while (GameManager.Manager.GameState)
        {
            QA.createAnswers();
            gameUI.obj.drawGameUI();

            //Timer & answer state checking
            for (short i = 0; i < GameManager.Manager.countdown; i++)
            {
                yield return new WaitForSeconds(1);
                gameUI.obj.drawTimerCountdown();
                if (i == GameManager.Manager.countdown - 1 || !GameManager.Manager.GameState)
                {
                    GameManager.Manager.tempwidth = GameManager.Manager.width * 2;
                    GameManager.Manager.gameStop();
                    break;
                }
                else if (QA.isCorrect)
                {
                    GameManager.Manager.tempwidth = GameManager.Manager.width * 2;
                    QA.isCorrect = false;
                    break;
                }
            }
        }

        Debug.Log("Game State is False");
    }

    void Start()
    {
        GameManager.Manager.gameStart();
        //menuUI.obj.drawMenu();
        StartCoroutine(gameLoop());
    }
}
