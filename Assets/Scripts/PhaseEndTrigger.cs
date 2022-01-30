using UnityEngine;
using UnityEngine.Playables;
using System.Collections;
using UnityEngine.SceneManagement;

public class PhaseEndTrigger : MonoBehaviour
{
    
    public PlayableDirector phaseEnd;
    int cena;
    
    // Start is called before the first frame update
    void Start()
    {
        phaseEnd = this.gameObject.GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D c)
    {       
        phaseEnd.Play();
        StartCoroutine(SceneChange());    
    }



    IEnumerator SceneChange()
    {
        yield return new WaitForSeconds(3);
        cena = SceneManager.GetActiveScene().buildIndex;

        if (cena < 21)
        {
            SceneManager.LoadScene(cena + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
