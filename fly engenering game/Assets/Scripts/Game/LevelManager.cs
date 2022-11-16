using Assets.Scripts.Core;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _levelObjects = new List<GameObject>();

    private void Awake()
    {
        MessageSystem.Inctance.UIEvents.OnStartButtonClickEvent += OnStartButtonClick;
    }

    private void OnStartButtonClick()
    {
        //онялнрперэ б янупюмемхъ х бшапюрэ хг яохяйю мсфмши спнбемэ!
        GameObject.Instantiate(_levelObjects[0]);
    }
}
