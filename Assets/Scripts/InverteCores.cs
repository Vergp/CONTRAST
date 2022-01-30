using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverteCores : MonoBehaviour
{

    public Animator painel;
    /*void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!painel.GetCurrentAnimatorStateInfo(0).IsName("transicao")) { painel.SetBool("transicao", true); }
            Invoke("inverteFilhos", 0.2f); //delay de 0.2 segundos antes de realizar a troca de cor
        }
    }*/
    public void transicaoCor()
    {
        if (!painel.GetCurrentAnimatorStateInfo(0).IsName("transicao")) { painel.SetBool("transicao", true); }
        Invoke("inverteFilhos", 0.2f); //delay de 0.2 segundos antes de realizar a troca de cor
    }

    private void inverteFilhos()
    {
        gameObject.BroadcastMessage("inverte");
    }


}
