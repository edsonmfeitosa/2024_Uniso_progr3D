using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miraController : MonoBehaviour
{
    [Header("Mira Laser")]
    [SerializeField] private LineRenderer line;
    [SerializeField] private GameObject laser;
    [SerializeField] private float distancia;
    [SerializeField] private KeyCode habilitarLaser;
    private bool laserHabilitado = false;

    void Start()
    {
        
    }
    void Update()
    {
        line.SetPosition(0, laser.transform.position);
        line.SetPosition(1, laser.transform.forward * distancia);

        if (Input.GetKeyDown(habilitarLaser))
        {
            laserHabilitado = !laserHabilitado;
        }
        if (laserHabilitado)
            laser.SetActive(true);
        else
            laser.SetActive(false);

    }
}
