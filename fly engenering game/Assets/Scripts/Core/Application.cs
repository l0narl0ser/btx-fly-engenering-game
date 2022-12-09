using Assets.Scripts.Core;
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
            if (_intstance != null)
            {
                return _intstance;

            }

            _intstance = FindObjectOfType<Application>();

            return _intstance;
        }
    }

    private void Awake()
    {
        Context.Inctance.GetSnapshotManager().Load();
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {

        ///C��������
        Context.Inctance.GetSnapshotManager().Save();
        UnityEngine.Application.Quit();
    }

}
