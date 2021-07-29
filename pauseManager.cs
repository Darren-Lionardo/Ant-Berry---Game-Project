using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class pauseManager : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject pausePanel;
    public GameObject optionPanel;
    public Slider volumeSlider;
    float currentVolume;

    public void onClickPause(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void onClickResume(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
    public void onClickOption()
    {
        pausePanel.SetActive(false);
        optionPanel.SetActive(true);
    }

    public void onClickBack()
    {
        pausePanel.SetActive(true);
        optionPanel.SetActive(false);
    }
    public void onClickQuit(){
        pausePanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }


}
