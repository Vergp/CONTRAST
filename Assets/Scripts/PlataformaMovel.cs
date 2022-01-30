using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaMovel : MonoBehaviour
{
    [SerializeField] private GameObject[] pontos;
    private int indicePontos = 0;

    [SerializeField] private float speed = 2f;

    public Transform objPai;

    // Update is called once per frame

    void Update()
    {
            if (Vector2.Distance(pontos[indicePontos].transform.position, transform.position) < .1f)
            {
                indicePontos++;
                if (indicePontos >= pontos.Length)
                {
                    indicePontos = 0;
                }

            }
            transform.position = Vector2.MoveTowards(transform.position, pontos[indicePontos].transform.position, Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.collider.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //objPai = GameObject.FindWithTag("Chest").transform;
            collision.collider.transform.SetParent(objPai);
        }
    }
}
