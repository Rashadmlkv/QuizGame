using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;


    public int width, height, tempwidth;
    public short countdown = 5;
    private bool gameState = false;

    public bool GameState
    {
        get { return gameState;}
        set { gameState = value;}
    }

    public void gamePause()
    {
        while(true)
        {

        }
    }

    public void gameStart()
    {
        gameState = true;
    }

    public void gameStop()
    {
        gameState = false;
    }

    void Awake()
    {
        Manager = this;
        width = Screen.currentResolution.width;
        height = Screen.currentResolution.height;
        tempwidth = width * 2;
    }
}
