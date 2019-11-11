using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
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

    }

    //TODO: Create methods that influence difficulty in three modes (Maybe by changing the speed of cubes).
}
