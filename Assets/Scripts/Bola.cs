using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    public GameObject objetoPai;
    public GameObject player;

    private bool _podeApertar;

    void Update()
    {
        if (_podeApertar)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                _podeApertar = false;
                objetoPai.GetComponent<InverteCores>().transicaoCor();
                player.GetComponent<Player>().mudaDirecao();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
            _podeApertar = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            _podeApertar = false;
    }

}
