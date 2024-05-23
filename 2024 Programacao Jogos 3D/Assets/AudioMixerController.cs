using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMixerController : MonoBehaviour
{
    public AudioMixer mix;
    public float volumeLeao = 0;
    public float volumeSDA = 0;
    public float velocidadeSomLeao = 0;
    void Start()
    {
        
    }

    void Update()
    {
        mix.SetFloat("VolumeRei", volumeLeao);
        mix.SetFloat("VolumeSDA", volumeSDA);
        mix.SetFloat("PitchRei", velocidadeSomLeao);
    }
}
