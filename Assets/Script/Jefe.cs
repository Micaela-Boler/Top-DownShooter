using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Jefe : Enemigo
{
    public delegate void ActivarPantallaParaGanar();
    public static ActivarPantallaParaGanar activarPantallaParaGanar;

    [Header("Transform de puntos de disparo")]

    [SerializeField] Transform armaDerecha;
    [SerializeField] Transform armaIzquierda;
    [SerializeField] Transform armaDetras;



    private void Start()
    {
        InvokeRepeating("DisparoEnemigo", 1, 1);
    }


    void Update()
    {
        base.MovimientoDeEnemigo();


        //int vidaEnemigo = gameObject.GetComponent<RecibirDaño>().vida;

        if (vida == 0)
        {
            activarPantallaParaGanar?.Invoke();
            Destroy(gameObject);
        }
    }

    void DisparoEnemigo()
    {
        Disparar(transform.forward, ArmaDelante);
        Disparar (transform.right, armaDerecha);
        Disparar(-transform.right, armaIzquierda);
        Disparar(-transform.forward, armaDetras);
    }
    
}
