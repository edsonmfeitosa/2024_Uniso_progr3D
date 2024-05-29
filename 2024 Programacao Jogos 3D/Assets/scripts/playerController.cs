using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Animator anim;
    public bool andar = false;
    public bool sambar = false;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetBool("podeAndar", andar);
        anim.SetBool("podeSambar", sambar);
    }
}
