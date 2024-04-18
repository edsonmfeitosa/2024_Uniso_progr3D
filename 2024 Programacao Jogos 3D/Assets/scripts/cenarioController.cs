using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cenarioController : MonoBehaviour
{
    [SerializeField] private Transform personagem;
    [SerializeField] private Transform agua;
    [SerializeField] private Color corDaAgua;
    [SerializeField] private float densidade;
    void Start()
    {
        
    }

    void Update()
    {
        if (personagem.position.y < agua.position.y)
        {
            //debaixo da água
            RenderSettings.fog = true;
            RenderSettings.fogMode = FogMode.Exponential;
            RenderSettings.fogColor = corDaAgua;
            RenderSettings.fogDensity = densidade;
        }
        else
        {
            //emcima da água
            RenderSettings.fog = false;
        }
    }
}
