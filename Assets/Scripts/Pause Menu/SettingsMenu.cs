using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    
    private void Awake()
    {
        GameObject slider = GameObject.Find("Slider");
        slider.GetComponent<Slider>().value = AudioManagement.instance.GetVolume();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (PauseMenu.instance.GamePaused)
            {
                PauseMenu.instance.Resume();
            }
        }
    }
    public void SetVolume(float volume)
    {
        AudioManagement.instance.SetVolume(volume);
    }
}
