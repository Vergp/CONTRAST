using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhaseSelection : MonoBehaviour
{
    [SerializeField] private int Phase;
    public void SelectPhase()
    {
        SceneManager.LoadScene(Phase);
    }
}
