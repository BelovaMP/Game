using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class DialogMer : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string textER;
    public string nameNPC;
    public int count;

    public GameObject mer;
    public GameObject mer1;

    public string[] message;
    public bool dialogStart = false;

    public int questNumber;
    public int[] items;
 
    
    void Start()
    {      
        count = 0;   
        textER = "[E]";
        nameNPC = "Мэр";
        message[0] = "Ты что-то сказал?..";   
        message[1] = "Хмм... показалось...";
        message[2] = "А ты собеседник так себе,но я подозреваю для чего ты здесь...";
        message[3] = "Мне так скучно... давай поиграем и я дам тебе подозрительную склянку со дна, которую выкинули лет 10 назад, может пригодится";
        message[4] = "Как насчёт пряток? В здешней деревеньке это озеро не единственный источник воды, найди меня 5 раз и склянка твоя, просто, не так ли?";       
        // message[5] = "1 раз нашёл, осталось всего 4)";  
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
                textE.text = "[E]";
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
                mer1.SetActive(true);
                count++;
            }
            //  else if (count == 5)
            // {
            //     mer.SetActive(false);
            //     mer1.SetActive(true);
            //     count++;
            // } 
            //    else if (count == 6)
            // {
            //     panelDialog.SetActive(true);
            //     dialog.text = message[5];
            //     name.text = nameNPC;
            //     textE.text = "";
            //     dialogStart = true;
            //     count++;
            // }                                         
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {        
        panelDialog.SetActive(false);
        dialogStart = false;
        if(count == 5)
        {
            mer.SetActive(false);
            mer1.SetActive(true);
        }
    }

    public void CheckQuest()
    {
        if (questNumber == 1)
        {
           
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
                textE.text = "[E]";
                count++;
            }
            else if(Input.GetKeyDown(KeyCode.E) && count == 4)
            {
                dialog.text = message[4];
                textE.text = "";
                count++;
            }           
        }
    }
}

