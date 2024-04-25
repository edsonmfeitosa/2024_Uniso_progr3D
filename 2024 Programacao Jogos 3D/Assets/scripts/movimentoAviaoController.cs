using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoAviaoController : MonoBehaviour
{
    [Header("Movimento da Elise")]
    [Tooltip("Velocidade da elise")]
    [SerializeField] private float fatorDeGiro;
    [SerializeField] private GameObject elise;
    [Header("Movimento do Avião")]
    [SerializeField] private KeyCode paraCima;
    [SerializeField] private KeyCode paraBaixo;
    [SerializeField] private KeyCode paraDireita;
    [SerializeField] private KeyCode paraEsquerda;
    [SerializeField] private KeyCode acelerador;
    [SerializeField] private KeyCode freio;
    private float velocidade = 0;

    private bool ligado = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (ligado)
        {
            giroDaElise();
            movimento();
        }
    }
    public void movimento()
    {
        #region acelerar/frear
        if (Input.GetKey(acelerador))
        {
            velocidade -= Time.deltaTime;
        }
        if (Input.GetKey(freio)) 
        {
            if (velocidade < 0)
            {
                velocidade += Time.deltaTime;
                if (velocidade >= 0)
                {
                    velocidade -= Time.deltaTime;
                }
            }
        }
        #endregion

        #region virar o avião
        float movX = 0;
        float movY = 0;
        if(Input.GetKey(paraCima))
        {
            movX = -1;
        }
        if (Input.GetKey(paraBaixo))
        {
            movX = 1;
        }
        if (Input.GetKey(paraDireita))
        {
            movY = 1;
        }
        if (Input.GetKey(paraEsquerda))
        {
            movY = -1;
        }
        #endregion

        transform.Translate(Vector3.up * velocidade);
        transform.Rotate(movX, movY, movY);
    }
    public void giroDaElise() {
        elise.transform.Rotate(new Vector3(0, fatorDeGiro * Time.deltaTime, 0));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "jogador")
        {
            ligado = true;
            collision.gameObject.SetActive(false);
            //Destroy(collision.gameObject);
        }
    }
}
