using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPulo : MonoBehaviour
{
    public float tempoSuperPulo = 0;
    public static bool usarSuperPulo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (usarSuperPulo)
        {
            tempoSuperPulo += Time.deltaTime;
            if (tempoSuperPulo > 3)
            {
                usarSuperPulo = false ;
                tempoSuperPulo = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "exemplo")
        {
            usarSuperPulo = true;
        }
    }
}
