using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class DialogSup : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string textER;
    public string nameNPC;
    public int count = 0;

    public GameObject carrot;
    public GameObject cat;
    public string[] message;
    public bool dialogStart = false;

    public int questNumber;
    public int[] items;

    void Start()
    {           
        textER = "[E]";
        nameNPC = "Сапсан";
        message[0] = "Что ты забыл в лесу?";   
        message[1] = "Хотя выглядил бы я как ты, тоже ушёл бы подальше от людей";
        message[2] = "Тебе повезло встретиться сомной, я как раз таки знаю одну мекстурку от всего";
        message[3] = "Но у меня не хватает ингридиентов, д и за спасибо я работать не стану. Я дам тебе список, принеси мне всё, тогда может и смогу помочь.";
        message[4] = "А ты, как я вижу, не спешишь. В блокноте ты найдёшь рецепт, принеси мне всё для мекстуры.";
        panelDialog.SetActive(false);   
    }

     private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.tag == "Player")
        {
            if (count == 0)
           {      
            panelDialog.SetActive(true);
            textE.text = textER;
            cat.SetActive(true);
            name.text = nameNPC;
            dialog.text = message[0];
            dialogStart = true;
            count++;
           }
            else if (count == 1)
           {           
            panelDialog.SetActive(true);
            textE.text = textER;
            name.text = nameNPC;
            dialog.text = message[1];
            dialogStart = true;
            count++;
           }
            
            else if (count == 2)
            {
                panelDialog.SetActive(true);
                dialog.text = message[2];
                name.text = nameNPC;
                textE.text = "[E]";
                dialogStart = true;
                count++;
            }
            else if (count == 3)
            {
                panelDialog.SetActive(true);
                dialog.text = message[3];
                name.text = nameNPC;
                textE.text = "";
                dialogStart = true;
                count++;
            }
            else if (count == 4)
            {
                panelDialog.SetActive(true);
                dialog.text = message[4];
                name.text = nameNPC;
                textE.text = "";
                dialogStart = true;
                
            }
                                             
        }   
        if(collision.tag != "Player" && collision.gameObject.GetComponent<Pickup>().id == items[questNumber])
        {
            panelDialog.SetActive(true);
            textE.text = "";
            name.text = nameNPC;
            dialog.text = message[3];
            dialogStart = true;
            count++;

            questNumber++;
            Destroy(collision.gameObject);
            CheckQuest();
        }          
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        panelDialog.SetActive(false);
        dialogStart = false;
    }

    public void CheckQuest()
    {
        if (questNumber == 1)
        {
            carrot.SetActive(true);
        }
    }

     void Update()
    {
        if (dialogStart == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && count < 2)
            {
                dialog.text = message[1];
                textE.text = "[E]";
                count++;
            }
            else if(Input.GetKeyDown(KeyCode.E) && count == 2)
            {
                dialog.text = message[2];
                textE.text = "[E]";
                count++;
            }
            else if(Input.GetKeyDown(KeyCode.E) && count == 3)
            {
                dialog.text = message[3];
                textE.text = "";
                count++;
            }
        }
    }
}
