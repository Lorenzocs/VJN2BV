using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolaChicos : MonoBehaviour
{
    public int quePasoAca;
    void Start()
    {
       
        quePasoAca = PlayerPrefs.GetInt("NivelDesbloqueado", 0);
        quePasoAca++;
        PlayerPrefs.SetInt("NivelDesbloqueado", quePasoAca);
        PlayerPrefs.Save();


    }

    // Update is called once per frame
    void Update()
    {

    }
}
