using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Application : MonoBehaviour
{
    private static Application _intstance;

    public static Application Inctance
    {
        get
        {
            if(_intstance != null)
            {
                return _intstance;

            }
           
            _intstance = FindObjectOfType<Application>();
            return _intstance;
        }
    }



    public void Restart()
    {
        // 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     
    }

    public void Exit()
    {

        ///Cохранени
        UnityEngine.Application.Quit();
    }

}
