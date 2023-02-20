using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class DialogManager : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialog;
    public Text name;
    public Text textE;
    public string textER;
    public string nameNPC;
    public int count;

    public GameObject carrot;
    public GameObject cat;
    public string[] message;
    public bool dialogStart = false;

    public int questNumber;
    public int[] items;

    void Start()
    {
        //questBa = other.GameObject.GetComponent<QuestBa>();
        count = 0;
        textER = "[E]";
        nameNPC = "Ба";
        message[0] = "Где же она? Убежала";   
        message[1] = "Помоги мне найти мою кошку, она должно быть убежала в лес";
        message[2] = "Ты не видел мою кошку?";
        message[3] = "Спасибо тебе, но денег у меня нет, держи морковку";
        panelDialog.SetActive(false);   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {      
        if(collision.tag == "Player")
        {
            if (count == 1)
           {           
            panelDialog.SetActive(true);
            textE.text = textER;
            name.text = nameNPC;
            dialog.text = message[2];
            dialogStart = true;
           }
            else if (count == 0)
           {      
            panelDialog.SetActive(true);
            textE.text = textER;
            cat.SetActive(true);
            name.text = nameNPC;
            dialog.text = message[0];
            dialogStart = true;
            count++;
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

    void Update()
    {
        if (count == 2)
        {
            panelDialog.SetActive(true);
            textE.text = "";
            name.text = nameNPC;
            dialog.text = message[3];
            dialogStart = true;
            count++;
        } 

        if (dialogStart == true)
        {
            if(Input.GetKeyDown(KeyCode.E) && count < 2)
            {
                textE.text = "";
                dialog.text = message[1];               
            }
        }
    }

    public void CheckQuest()
    {
        if (questNumber == 1)
        {
            carrot.SetActive(true);
        }
    }
}
