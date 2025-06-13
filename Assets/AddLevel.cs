using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLevel : MonoBehaviour
{
    public int nivelActual;
    void Start()
    {
        nivelActual = PlayerPrefs.GetInt("NivelProgra", 0);
        nivelActual++;
        print(System.DateTime.Now);
        PlayerPrefs.SetInt("NivelProgra", nivelActual);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
