using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject pantallaDeGanar;
    [SerializeField] GameObject jugador;

    [SerializeField] GameObject jefe;
    [SerializeField] Vector3 spawnJefe;

    [SerializeField] int objetivoDeKills;
    [SerializeField] int contadorDeKills;
    [SerializeField] Text kills;


    [SerializeField] Text puntajeTexto;
    int cantidadDePuntos;


    [SerializeField] List<GameObject> corazones = new List<GameObject>();
    [SerializeField] Sprite corazonDesactivado;


    void Start()
    {
        pantallaDeGanar.SetActive(false);
        jefe.SetActive(false);
    }

    void Update()
    {
        if (jugador == null)
            SceneManager.LoadScene(0);
    }


    public void CambiarCorazon(int indice) 
    {
        Image imagenCorazon = corazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;
    }


    public void ContadorDeKills()
    {
        contadorDeKills++;
        kills.text = "Kills: " + contadorDeKills;

        if (contadorDeKills == objetivoDeKills)
            jefe.SetActive(true);
    }


    // EVENTOS //

    void ActualizarPuntaje(int ValorDePunto)
    {
        cantidadDePuntos += ValorDePunto;
        puntajeTexto.text = "Puntaje: " + cantidadDePuntos;
    }

    public void Ganar()
    {
        pantallaDeGanar.SetActive(true);
        Time.timeScale = 0;
    }


    private void OnEnable()
    {
        Coleccionable.Punto += ActualizarPuntaje;
        Jefe.activarPantallaParaGanar += Ganar;
    }

    private void OnDisable()
    {
        Coleccionable.Punto -= ActualizarPuntaje;
        Jefe.activarPantallaParaGanar -= Ganar;
    }
}
