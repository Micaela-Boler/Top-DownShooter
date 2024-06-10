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

    protected override void RecibirDañoEnemigo(int daño)
    {
        vida -= daño;
        gameManager.CambiarCorazon(vida);


        if (vida == 0)
        {
            //animator.SetTrigger("SinVida");
            Destroy(gameObject, 1f);
        }
        else
        {
            recibirDaño.Play();
            //animator.SetTrigger("RecibirGolpe");
        }
    }
}
