using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticulasLluvia : MonoBehaviour
{
    public ParticleSystem particulas;
    public float cantidad;
    void Start()
    {
        particulas = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var emision = particulas.emission; 
        emision.rateOverTime = cantidad;
       
    }
}
