using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemController : MonoBehaviour
{
    public Vector3 movItem;
    public CenaController control;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(movItem);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "bolinha")
        {
            control.quantidadeItens++;
            Destroy(gameObject);
        }
    }
}
