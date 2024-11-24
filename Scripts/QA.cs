using UnityEngine;
using System.Linq;
public class QA
{
    static short randindex = 0;
    public static bool isCorrect = false;
    //Create random choosen questions list
    //Fill with -1 for rand 0 case
    //Choose random index between 0 & question's length
    //Check if list contains that number
    //Add or Rechoose
    public static void createQuestions()
    {
        levelData.obj.questions = Enumerable.Repeat<short>(-1, levelData.obj.questions.Length).ToArray();

        for (int i = 0; i < levelData.obj.questions.Length; i++)
        {
            randindex = (short)Random.Range(0, levelData.obj.questions.Length);

            if (!levelData.obj.questions.Contains(randindex))
            {
                levelData.obj.questions[i] = randindex;
            }
            else
            {
                --i;
            }
        }
    }

    //Create random choosen answers list
    //Fill with -1 for rand 0 case
    //Choose random cell to put correct answer
    //Choose random index between 0 & question's length
    //Check if list contains that number
    //Add or Rechoose
    public static void createAnswers()
    {
        levelData.obj.answers = Enumerable.Repeat<short>(-1, levelData.obj.answers.Length).ToArray();
        levelData.obj.cell = (short)Random.Range(0, levelData.obj.answers.Length);

        for (int i = 0; i < levelData.obj.answers.Length; i++)
        {
            if (i == levelData.obj.cell)
            {
                levelData.obj.answers[i] = levelData.obj.questions[levelData.obj.currentQuestion];
                continue;
            }

            randindex = (short)Random.Range(0, levelData.obj.questions.Length);

            if (!levelData.obj.answers.Contains(randindex) && randindex != levelData.obj.questions[levelData.obj.currentQuestion])
            {
                levelData.obj.answers[i] = randindex;
            }
            else
            {
                --i;
            }
        }
    }

    public static void rightAnswer()
    {
        isCorrect = true;

        if (levelData.obj.currentQuestion == levelData.obj.questions.Length-1)
        {
            levelData.obj.currentQuestion = 0;
            levelData.obj.currentLevel++;
            GameManager.Manager.gameStop();
        }
        else
            levelData.obj.currentQuestion++;
    }
}
