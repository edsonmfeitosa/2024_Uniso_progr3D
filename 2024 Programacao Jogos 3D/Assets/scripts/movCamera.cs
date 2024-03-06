using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movCamera : MonoBehaviour
{
    private Vector3 posicaoInicial;
    private Vector3 posicaoAtual;
    public GameObject bolinha;
    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial = bolinha.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        posicaoAtual = bolinha.transform.position;
        transform.position = transform.position +
            (posicaoAtual - posicaoInicial);
        posicaoInicial = bolinha.transform.position;
    }
}
