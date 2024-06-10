using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Arma : MonoBehaviour
{
    [Header("Disparo")]
    [SerializeField] protected GameObject balaPrefab;
    [SerializeField] protected Transform ArmaDelante;
    [SerializeField] protected float fuerzaDeDisparo;
    [SerializeField] protected float tiempoParaDestruirse;

    [SerializeField] protected AudioSource audio;


    [Header("Recibir da�o")]

    [SerializeField] protected string nombreDeobjeto;
    [SerializeField] protected int da�o;
    public int vida;

    public GameManager gameManager;

    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource recibirDa�o;


    protected abstract void RecibirDa�oEnemigo(int da�o);

    /*
    void RecibirDa�oMetodo(int da�o)
    {
        vida -= da�o;

        if (vida == 0)
        {
            gameManager.ContadorDeKills();
            enemigo.BuscarDestino(transform);

            animator.SetTrigger("SinVida");
            Destroy(gameObject, 2f);
        }
        else
        {
            recibirDa�o.Play();
            animator.SetTrigger("RecibirGolpe");
        }
    }
    */
    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag(nombreDeobjeto))
        {
            RecibirDa�oEnemigo(da�o);
        }
    }
    

    public virtual void Disparar(Vector3 direccion, Transform puntoDeDisparo)
    {
        GameObject clonBala = Instantiate(balaPrefab, puntoDeDisparo.position, Quaternion.identity);
        Rigidbody balaRB = clonBala.GetComponent<Rigidbody>();

        balaRB.AddRelativeForce(direccion * fuerzaDeDisparo, ForceMode.Impulse);

        audio.Play();
        Destroy(clonBala, tiempoParaDestruirse);
    }
}
