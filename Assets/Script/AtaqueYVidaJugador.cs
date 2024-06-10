using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueYVidaJugador : Arma
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Disparar(-transform.forward, ArmaDelante);
    }

    protected override void RecibirDa�oEnemigo(int da�o)
    {
        vida -= da�o;
        gameManager.CambiarCorazon(vida);


        if (vida == 0)
        {
            //animator.SetTrigger("SinVida");
            Destroy(gameObject, 1f);
        }
        else
        {
            recibirDa�o.Play();
            //animator.SetTrigger("RecibirGolpe");
        }
    }
}
