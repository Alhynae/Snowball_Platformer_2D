using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioMixer mainMixer;
     public AudioMixer soundMixer;
    public AudioSource ost;
    public AudioClip pausedSound;
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                ost.PlayOneShot(pausedSound);
                Resume();
            } else
            {
                ost.PlayOneShot(pausedSound);
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        ost.volume = 0.3f;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        ost.volume = 0.1f;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    
    public void SetVolume (float volume)
    {
        mainMixer.SetFloat("Volume", volume);
    }

     public void SetSound(float volume)
    {
        soundMixer.SetFloat("Sound", volume);
    }

}
