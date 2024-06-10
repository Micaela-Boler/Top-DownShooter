using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMov : MonoBehaviour
{
    [SerializeField] Transform jugador;
    [SerializeField] Vector3 offsetCamara;
    [SerializeField] float velocidad;

    void Update()
    {
        if (jugador != null)
            transform.position = Vector3.Lerp(transform.position, jugador.position + offsetCamara, velocidad * Time.deltaTime);
    }
}
