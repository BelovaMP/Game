using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class mer3 : MonoBehaviour
{
     public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string nameNPC;
    public bool dialogStart = false;

    public GameObject mer03;
    public GameObject mer4;

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
            dialog.text = "Опять? осталось 2...";
            dialogStart = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {        
        mer4.SetActive(true);
        mer03.SetActive(false);
        panelDialog.SetActive(false);
        dialogStart = false;
    }
}
