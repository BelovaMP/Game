using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class mer2 : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string textER;
    public string nameNPC;
    public int count;
    public bool dialogStart = false;

    public GameObject mer02;
    public GameObject mer3;

    void Start()
    {
        nameNPC = "Мэр";
        panelDialog.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.tag == "Player")
        {
            if (count == 0)
           {      
            panelDialog.SetActive(true);
            textE.text = "";
            name.text = nameNPC;
            dialog.text = "И снова нашёл, осталось 3";
            dialogStart = true;
            count++;
           }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {               
        panelDialog.SetActive(false);
        dialogStart = false;
        mer3.SetActive(true);
        mer02.SetActive(false);
    }
}
