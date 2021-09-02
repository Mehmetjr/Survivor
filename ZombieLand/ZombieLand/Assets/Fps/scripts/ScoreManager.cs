using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int currentScore = 0;
    public int score = 0;
    private static ScoreManager _instance;
    private void Awake()
    {
        _instance = this;

        LevelManager levelManager = LevelManager.GetInstance();
        switch (levelManager.currentLevel)
        {
            case 0:
                score = levelManager.easyScore;
                break;

            case 1:
                score = levelManager.mediumScore;
                break;

            default:
                Debug.Log("There is an issue with the Level Manager Script");
                break;
        }
    }

    public static ScoreManager GetInstance() { return _instance; }

    public int IncreaseScore()
    {
        currentScore += score;


        return currentScore;
    }
}
