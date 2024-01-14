using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Pause;
    public GameObject TitleScreen;
    public Slider VolumeSlider;

    public void PauseGame()
    {
        HUD.SetActive(false);
        Pause.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void ContinueGame()
    {
        HUD.SetActive(true);
        Pause.SetActive(false);
        Time.timeScale = 1.0f;

    }

    public void MainMenu()
    {
        TitleScreen.SetActive(true);
        HUD.SetActive(false);
        Pause.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Volume()
    {
        AudioListener.volume = VolumeSlider.value;
    }

    public void Start()
    {
        TitleScreen.SetActive(false);
        HUD.SetActive(true);
    }
}
