using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button Easy;
    public Button Medium;
    public LevelManager levelManager;
  //  playerHealth playerHealth;

    public void Start()
    {
      //  playerHealth = GetComponent<playerHealth>();
    }

    public void SelectLevel(int levelID)
    {
        levelManager.currentLevel = levelID;
        SceneManager.LoadScene(2);
    }

}
