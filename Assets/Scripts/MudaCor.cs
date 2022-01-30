using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudaCor : MonoBehaviour
{
    // Reference to Sprite Renderer component
    private Renderer rend;

    private Color[] cores = { new Color(1f,1f,1f,1f),               //BEGE
                              new Color(0.118f,0.161f,0.255f,1f)};  //PRETO AZULADO

    public enum enumCores
    {
        PRETO, BRANCO
    };

    public enumCores cor;
    private int indice_cor;
    // Use this for initialization

    private void Start()
    {
        // caso esteja invertido trocar para a cor X;
        //  caso não é branco
        rend = GetComponent<Renderer>();
        switch (cor)
        {
            case enumCores.BRANCO:
                indice_cor = 0;
                rend.material.color = cores[indice_cor];
                break;
            case enumCores.PRETO:
                indice_cor = 1;
                rend.material.color = cores[indice_cor];
                break;
            
        }
    }

    public void inverte()
    {
        
        indice_cor +=  1;
        if (indice_cor > (cores.Length - 1))
        {
            indice_cor = 0;
        }
    
        rend.material.color = cores[indice_cor];
    }
}
