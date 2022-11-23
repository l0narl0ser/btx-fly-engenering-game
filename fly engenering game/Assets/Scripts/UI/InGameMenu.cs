using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts.Core;

public class InGameMenu : MonoBehaviour
{
    [SerializeField]
    private Button _pauseButton;



    private void Start()
    {
        _pauseButton.onClick.AddListener(OnClickButton);
    }
    public void OnClickButton()
    {
        Context.Inctance.GetMessageSystem().UIEvents.PauseButtonClickEvent();
        Time.timeScale = 0;
    }

}
