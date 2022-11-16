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
        //���������� � ���������� � ������� �� ������ ������ �������!
        GameObject.Instantiate(_levelObjects[0]);
    }
}
