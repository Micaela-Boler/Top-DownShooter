using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemigo : Arma
{
    [Header("Movimiento enemigo")]

    public NavMeshAgent agente;
    [SerializeField] protected Transform jugador;
    GameObject _jugador;


    [Header("Ataque enemigo")]

    [SerializeField] protected float Repeticion;
    [SerializeField] protected float DelayInicial;
    [SerializeField] protected float distanciaParaAtacar;



    protected void Awake()
    {
        _jugador = GameObject.FindGameObjectWithTag("Jugador");
    }

    protected void Update()
    {
        if (jugador != null) 
            MovimientoDeEnemigo();
    }



    protected virtual void MovimientoDeEnemigo()
    {
        BuscarDestino(_jugador.transform);

        if (Vector3.Distance(_jugador.transform.position , transform.position) <= distanciaParaAtacar)
        {
            BuscarDestino(transform);
            animator.SetBool("Atacar", true);
        }
        else
        {
            animator.SetBool("Atacar", false);
            animator.SetBool("Caminar", true);
        }
    }

    public void BuscarDestino(Transform destino)
    {
        agente.destination = destino.position;
    }


    protected override void RecibirDañoEnemigo(int daño)
    {
        vida -= daño;

        if (vida == 0)
        {
            gameManager.ContadorDeKills();
            BuscarDestino(transform);

            animator.SetTrigger("SinVida");
            Destroy(gameObject, 2f);
        }
        else
        {
            recibirDaño.Play();
            animator.SetTrigger("RecibirGolpe");
        }
    }
}
