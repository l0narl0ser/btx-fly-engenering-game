using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PauseButton : MonoBehaviour
{
    [SerializeField]
    private Button _pauseButton;

    [SerializeField]
    private GameObject _menu;

    void Start()
    {
        _pauseButton.onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        Debug.Log("OnClickButton");
        _menu.SetActive(true);
        //Time.timeScale = 0;
    }


    void Update()
    {
        
    }
}
