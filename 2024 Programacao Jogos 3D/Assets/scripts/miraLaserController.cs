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

    [Header("Mira Luneta")]
    [SerializeField] private GameObject cameraLuneta;
    [SerializeField] private KeyCode habilitarLuneta;
    private bool lunetaHabilitado = false;

    void Start()
    {
        
    }
    void Update()
    {
        #region Laser
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
        #endregion
        #region Luneta
        if (Input.GetKeyDown(habilitarLuneta))
        {
            lunetaHabilitado = !lunetaHabilitado;
        }
        if(lunetaHabilitado)
            cameraLuneta.SetActive(true);
        else 
            cameraLuneta.SetActive(false);

        #endregion

    }
}
