using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]

public class MainMenu : MonoBehaviour
{

    //public GameObject UI_Game;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        //UI_Game.SetActive(true);

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
