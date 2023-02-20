using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleClass : MonoBehaviour
{
   public void ExiteGame()
   {
         Debug.Log("Игра закрылась");
         Application.Quit();    // закрыть приложение
   }
}
