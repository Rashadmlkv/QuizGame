using UnityEngine;
using System.Collections.Generic;
public class levelData : MonoBehaviour
{
    public static levelData obj;

    public string[,] days = {
        {"Monday","Bazar ertesi"},
        {"Tuesday","Cersenbe axsami"},
        {"Wednesday","Cersenbe"},
        {"Thursday","Cume axsami"},
        {"Friday","Cume"},
        {"Saturday","Senbe"},
        {"Sunday","Bazar"}
        };

    public string[,] months = {
        {"Monday","Bazar ertesi"},
        {"Tuesday","Cersenbe axsami"},
        {"Wednesday","Cersenbe"},
        {"Thursday","Cume axsami"},
        {"Friday","Cume"},
        {"Saturday","Senbe"},
        {"Sunday","Bazar"}
        };
    public string[][,] levels = new string[2][,];
    public short[] questions, answers;
    public short currentLevel = 0, currentQuestion = 0, cell = 0;
    public Dictionary<int, string> levelNames;

    void Awake()
    {
        obj = this;
    }

    void Start()
    {
        levelNames = new Dictionary<int, string>
        {
            { 0, "days" },
            { 1, "months" }
        };
        levels[0] = days;
        levels[1] = months;
        questions =  new short[levels[currentLevel].Length /2];
        answers = new short[4];
    }
}
