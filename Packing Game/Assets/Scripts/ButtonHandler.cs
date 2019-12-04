﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    public Board board;
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public void SettingsMenu()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
    public void MainStore()
    {
        SceneManager.LoadScene("MainStore", LoadSceneMode.Single);
    }
    public void EndGame()
    {
        Application.Quit();
    }
    public void PowerUp()
    {

        //Does nothing right now.
    }
    public void Pause()
    {
        board.Pause();
    }
    public void Resume()
    {
        board.Pause();
    }
}
