using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class mer4 : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string nameNPC;
    public bool dialogStart = false;

    public GameObject mer04;
    public GameObject mer5;

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
            dialog.text = "Ты подглядываешь??? Ещё 1";
            dialogStart = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {        
        mer5.SetActive(true);
        mer04.SetActive(false);
        panelDialog.SetActive(false);
        dialogStart = false;
    }
}
