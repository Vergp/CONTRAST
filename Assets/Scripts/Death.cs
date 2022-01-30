using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!Player.instance.isAlive)
        {
            Animator anim = gameObject.GetComponent<Animator>();
            anim.SetBool("isdead", true);
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("TryAgain"))
            {
                Invoke("ReiniciaFase", anim.GetCurrentAnimatorClipInfo(0).Length);
            }
        }
    }


    void ReiniciaFase() { PauseMenu.instance.Restart(); }
}
