﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private bool isPaused;
    public GameObject GameOverMenu;
   private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverMenu.activeSelf)
        {
            isPaused = !isPaused;
        }
        if(isPaused)
        {
            ActivateMenu();
        }else
        {
            DeactivateMenu();
        }
    }

    void ActivateMenu()
    {
        Time.timeScale = 0;
        pauseMenuUI.SetActive(true);
    }

    void DeactivateMenu()
    {
        Time.timeScale = 1;
        pauseMenuUI.SetActive(false);
    }
}
