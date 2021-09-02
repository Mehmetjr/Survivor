using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour
{
    public Text scoreText;

    public void UpdateScore ()
    {
        scoreText.text = "Score: " + ScoreManager.GetInstance().IncreaseScore().ToString();
    }
}
