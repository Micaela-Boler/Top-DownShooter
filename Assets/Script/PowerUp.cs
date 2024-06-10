using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] Transform arma1;
    [SerializeField] Transform arma2;
    [SerializeField] Transform arma3;

    [SerializeField] float duracionPowerUp;

    public Arma arma;
    //[SerializeField] ParticleSystem particulas;
    //[SerializeField] AudioSource audio;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            InvokeRepeating("empezarAdisparar", 0, 0.5f);


            //audio.Play();
            // particulas.Play();
            Destroy(other.gameObject, 0.1f);
        }
    }


    void empezarAdisparar()
    {
        StartCoroutine("PowerUpActivado");
    }



    IEnumerator PowerUpActivado()
    {
        arma.Disparar(transform.right, arma1);
        arma.Disparar(-transform.right, arma2);
        arma.Disparar(transform.forward, arma3);

        yield return new WaitForSeconds(duracionPowerUp);

        CancelInvoke("empezarAdisparar");
        //particulas.Stop();
    }
}
