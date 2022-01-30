using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public Animator animator;
    public string cor;
    
    void Start ()
    {
        inverte ();
    }
    
    
    void inverte ()
    {
        switch (cor)
        {
            case "BRANCO":
            case "branco":
                cor = "PRETO";
                animator.SetBool("black", false);
                break;
            case "PRETO":
            case "preto":
                cor = "BRANCO";
                animator.SetBool("black", true);
                break;
        }
    }
}
