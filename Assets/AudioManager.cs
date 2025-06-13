using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> audios;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlaySound(string nombreAudio)//gruñido
    {
        AudioClip clip = FindSound(nombreAudio);

        if (clip != null)
        {
            audioSource.PlayOneShot(clip, 0.1f);
        }
        else
        {
            Debug.LogWarning($"El sonido {nombreAudio} no existe en tu lista de clips");
        }
    }

    public AudioClip FindSound(string nombreClip)
    {
        for (int i = 0; i < audios.Count; i++)
        {
            if (nombreClip == audios[i].name)
            {
                return audios[i];
            }
        }
        return null;
    }
}