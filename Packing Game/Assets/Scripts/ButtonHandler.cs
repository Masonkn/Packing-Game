using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonHandler : MonoBehaviour
{
    public Board board;
    public AudioClip sound;
    private AudioSource audioSource;


    public void PlayGame()
    {
        FullyPlaySound();
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
    public IEnumerator FullyPlaySound()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound);
        yield return new WaitForSeconds(sound.length);
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
        FullyPlaySound();
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
