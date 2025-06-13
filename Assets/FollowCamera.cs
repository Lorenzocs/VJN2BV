using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform objetivo;
    public float tiempoSuavizado;
    public Vector3 offset;

    private Vector3 velocidad;
    void Start()
    {

    }



    private void LateUpdate()
    {

        Vector3 objetivoFinal = objetivo.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, objetivoFinal, ref velocidad, tiempoSuavizado);

        /*
        Vector3 posicionDeseada = objetivo.position + offset;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, tiempoSuavizado);
        transform.position = posicionSuavizada;
        */
    }
}
