using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoBolinha : MonoBehaviour
{

    [Header("Configuração")]
    private float movX;
    private float movZ;
    [SerializeField] private float velocidadeBola;
    private Rigidbody fisica;
    [SerializeField] private float forcaPulo;
    private bool estaNoChao = true;

    [Header("Entradas Teclado")]
    [SerializeField] private KeyCode paraFrente;
    [SerializeField] private KeyCode paraTraz;
    [SerializeField] private KeyCode paraEsquerda;
    [SerializeField] private KeyCode paraDireita;
    [SerializeField] private KeyCode teclaPulo;

    [Header("Configuração de sons")]
    [SerializeField] private AudioClip somDePulo;
    [SerializeField] private AudioClip somdeMorte;
    [SerializeField] private AudioClip somdeItem;
    private AudioSource som;
    private Vector3 posicaoAtual;

    // Start is called before the first frame update
    void Start()
    {
        fisica = GetComponent<Rigidbody>();
        som = GetComponent<AudioSource>();
        posicaoAtual = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5)
        {
            transform.position = posicaoAtual;
            som.PlayOneShot(somdeMorte);
        }

        #region 1ª forma de pegar o Input

        //movX = Input.GetAxis("Horizontal");
        //movZ = Input.GetAxis("Vertical");

        #endregion

        #region 2ª forma de pegar o Input
        movX = 0;
        movZ = 0;
        if (Input.GetKey(paraFrente))
        {
            movZ = 1;
        }
        if (Input.GetKey(paraTraz))
        {
            movZ = -1;
        }
        if (Input.GetKey(paraEsquerda))
        {
            movX = -1;
        }
        if (Input.GetKey(paraDireita))
        {
            movX = 1;
        }

        #endregion

        #region 1ª forma de aplicar o movimento
        //Vector3 posicao = new Vector3(movX, 0, movZ);
        //transform.Translate(new Vector3(movX, 0, movZ) * 
        //    Time.deltaTime *velocidadeBola);
        #endregion
        #region 2ª forma de aplicar o movimento
        fisica.AddForce(new Vector3(movX, 0, movZ) *
            Time.deltaTime * velocidadeBola);
        #endregion
        #region 3ª forma de aplicar o movimento
        //fisica.velocity = new Vector3(movX, 0, movZ) *
        //    Time.deltaTime * velocidadeBola;
        #endregion

        //pulo da bolinha
        if (Input.GetKeyDown(teclaPulo) && estaNoChao)
        {
            if (!som.isPlaying)
            {
                som.clip = somDePulo;
                som.Play();
            }
            
            if (SuperPulo.usarSuperPulo)
            {
                fisica.AddForce(new Vector3(0, 1, 0) *
                forcaPulo * 2, ForceMode.Impulse);
            }
            else
            {
                fisica.AddForce(new Vector3(0, 1, 0) *
                forcaPulo, ForceMode.Impulse);
            }

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "chao")
        {
            estaNoChao = true;
        }
        if (collision.collider.tag == "tesouro")
        {
            if (!som.isPlaying)
            {
                som.clip = somdeItem;
                som.Play();
            }
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "chao")
        {
            estaNoChao = false;
        }
    }
}
