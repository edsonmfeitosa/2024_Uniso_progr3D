using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoadController : MonoBehaviour
{
    public GameObject painel;
    private bool habilitado = false;
    public KeyCode habilitaPainel;
    public GameObject player;
    public InputField InpNome;
    public Text txtsave1;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(habilitaPainel))
            habilitado = !habilitado;

        if (habilitado)
        {
            painel.SetActive(true);
            Time.timeScale = 0;
            if (PlayerPrefs.HasKey("Save1"))
                txtsave1.text = PlayerPrefs.GetString("Save1");
        }
        else
        {
            painel.SetActive(false);
            Time.timeScale = 1;
        }
      
    }
    public void Salvar()
    {
        PlayerPrefs.SetString("Save1", InpNome.text);
        PlayerPrefs.SetFloat("Save1PosX", player.transform.position.x);
        PlayerPrefs.SetFloat("Save1PosY", player.transform.position.y);
        PlayerPrefs.SetFloat("Save1PosZ", player.transform.position.z);
        txtsave1.text = InpNome.text;
    }
    public void LoadSave1()
    {
        float x, y, z;
        x = PlayerPrefs.GetFloat("Save1PosX");
        y = PlayerPrefs.GetFloat("Save1PosY");
        z = PlayerPrefs.GetFloat("Save1PosZ");
        player.transform.position = new Vector3(x, y, z);
    }
}
