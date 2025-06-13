using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcionesSonido : MonoBehaviour
{
    public AudioMixer mixer;

    public Slider sliderMusica;
    public Slider sliderSonido;

    void Start()
    {
        if (sliderMusica != null)
        {
            float volumenMusica = PlayerPrefs.GetFloat("VolumenMusica", 0);
            mixer.SetFloat("VolumenMusica", volumenMusica);
            // mixer.GetFloat("VolumenMusica", out volumenMusica);
            sliderMusica.value = volumenMusica;
        }

        if (sliderSonido != null)
        {
            float volumenSonido = 0;
            mixer.GetFloat("VolumenSonido", out volumenSonido);
            sliderSonido.value = volumenSonido;
        }
    }

    public void ChangeVolumeMusic()
    {
        float volumenMusica = sliderMusica.value;
        mixer.SetFloat("VolumenMusica", volumenMusica);
        PlayerPrefs.SetFloat("VolumenMusica", volumenMusica);
    }

    public void ChangeVolumeSound()
    {
        float volumenSonido = sliderSonido.value;
        mixer.SetFloat("VolumenSonido", volumenSonido);
    }
}
