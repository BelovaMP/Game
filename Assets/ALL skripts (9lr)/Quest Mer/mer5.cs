using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class mer5 : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string nameNPC;
    public bool dialogStart = false;
    public int count = 0;

    public GameObject flask;


    void Start()
    {
        nameNPC = "Мэр";
        panelDialog.SetActive(false); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.tag == "Player")
        {    
            if(count == 0)
            {
            panelDialog.SetActive(true);
            textE.text = "[E]";
            name.text = nameNPC;
            dialog.text = "Везде нашёл, Злодей(";
            dialogStart = true;
            }
            if(count == 1)
            {
                panelDialog.SetActive(false); 
            }
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {        
        panelDialog.SetActive(false);
        dialogStart = false;
    }

     void Update()
    {
        if (dialogStart == true)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                flask.SetActive(true);
                dialog.text = "Держи ту склянку, не знаю поможет ли. Давай потом ещё поиграем, было весело.";
                textE.text = "";
                count++;
            }
        }
    }
}
