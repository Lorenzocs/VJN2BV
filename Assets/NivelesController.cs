using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NivelesController : MonoBehaviour
{
    public Button[] buttons;
    public int nivel;//2
    void Start()
    {

        nivel = PlayerPrefs.GetInt("NivelProgra",0);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = i<=nivel;
        }
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
