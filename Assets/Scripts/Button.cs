using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{   
    public void Clique()
    {
        GameObject audioManager;
        audioManager = GameObject.FindWithTag("AudioManager");
        audioManager.SendMessage("Play", "button_click");
    }
}
