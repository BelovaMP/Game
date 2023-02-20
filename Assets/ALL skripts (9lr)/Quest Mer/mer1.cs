using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class mer1 : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string nameNPC;
    public bool dialogStart = false;

    public GameObject mer01;
    public GameObject mer2;

    void Start()
    {
        nameNPC = "Мэр";
        panelDialog.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.tag == "Player")
        {    
            panelDialog.SetActive(true);
            textE.text = "";
            name.text = nameNPC;
            dialog.text = "1 раз нашёл, осталось всего 4)";
            dialogStart = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {        
        mer2.SetActive(true);
        mer01.SetActive(false);
        panelDialog.SetActive(false);
        dialogStart = false;
    }
}
