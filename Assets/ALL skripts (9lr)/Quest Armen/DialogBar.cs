using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]

public class DialogBar : MonoBehaviour
{
    public GameObject panelDialog;
    public Text dialogB;
    public Text nameB;
    public Text textE;
    public string textER;
    public string nameNPC;
    public int count;
    public string[] message;
    public bool dialogStart = false;

    
    public int questNumber;
    public int[] items;

    void Start()
    {
        count = 0;
        textER = "[E]";
        nameNPC = "Бармен Армен";
        message[0] = "Ого, выглядишь паршиво";   
        message[1] = "Если тебе нечем заняться, помоги мне убрать стаканы со столов." + '\n' + "Если поможешь, расскажу кое что интересное";
        message[2] = "Закончил?";
        message[3] = "Молодчик";
        message[4] = "Как погляжу ты что-то не то съел. Можешь обратиться к русалке, думаю это по её части)";
        message[5] = "Русалки живут на озере к югу отсюда. Но это женщины, сынок, они не самые сговорчивые.";
        message[6] = "Я тут пару рецептов попробовать хотел, подсобишь с ингридиентами?";
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
            nameB.text = nameNPC;
            dialogB.text = message[2];
            dialogStart = true;
           }
        else if (count == 0)
           {
            panelDialog.SetActive(true);
            textE.text = textER;
            nameB.text = nameNPC;
            dialogB.text = message[0];
            dialogStart = true;
            count++;
           }
        else if (count == 4)
           {
            panelDialog.SetActive(true);
            textE.text = "";
            nameB.text = nameNPC;
            dialogB.text = message[6];
            dialogStart = true;
            
           }
        }       

         if(collision.tag != "Player" && collision.gameObject.GetComponent<Pickup>().id == items[questNumber])
        {
            

            questNumber++;
            Destroy(collision.gameObject);
            CheckQuest();
        }

    }

    public void CheckQuest()
    {
        if (questNumber == 4)
        {
            panelDialog.SetActive(true);
            textE.text = textER;
            nameB.text = nameNPC;
            dialogB.text = message[3];
            dialogStart = true;
            count = 2;
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
            if(Input.GetKeyDown(KeyCode.E) && count < 2)
            {
                dialogB.text = message[1];
                textE.text = "";
            }

            else if(Input.GetKeyDown(KeyCode.E) && count == 2)
            {
                dialogB.text = message[4];
                textE.text = textER;
                count++;
            }

            else if(Input.GetKeyDown(KeyCode.E) && count == 3)
            {
                dialogB.text = message[5];
                textE.text = textER;
                count++;
            }

            else if(Input.GetKeyDown(KeyCode.E) && count == 4)
            {
                dialogB.text = message[6];
                textE.text = "";
            }
        }
    }
}
