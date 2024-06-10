using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JugadorMov : MonoBehaviour
{
    [Header("Ejes de movimientos")]

    private float horizontalInput;
    private float verticalInput;
    private Vector3 vectorDeMovemento;


    [Header("Velocidad de movimiento")]

    [SerializeField] float velocidad;



    void Update()
    {
        Movimiento();
        Rotacion();
    }


    void Movimiento()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        vectorDeMovemento = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        transform.Translate(vectorDeMovemento * Time.deltaTime * velocidad, Space.World);
    }


    void Rotacion()
    {
        RaycastHit hit;
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayo, out hit))
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

    }
}
