using Assets.Scripts.Core;
using Assets.Scripts.Game.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _levelObjects = new List<GameObject>();


    private MessageSystem _messageSystem;
    private SnapshotManager _snapshotManager;

    private void Awake()
    {
        _messageSystem = Context.Instance.GetMessageSystem();
        _snapshotManager = Context.Instance.GetSnapshotManager();
        _messageSystem.UIEvents.OnStartButtonClickEvent += OnStartButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished += OnLevelFinished;
    }

    private void OnLevelFinished(List<BalanceData> balanceDatas)
    {
        NextLevel();
    }

    private void NextLevel()
    {
        int savedLevelIndex = _snapshotManager.GetLevelIndex();
        savedLevelIndex++;
        _snapshotManager.SetLevelIndex(savedLevelIndex);
        _snapshotManager.Save();
  
    }

    private void OnStartButtonClick()
    {
        //ПОСМОТРЕТЬ В СОХРАНЕНИЯ И ВЫБРАТЬ ИЗ СПИСКА НУЖНЫЙ УРОВЕНЬ! SnapshotManager.GEtIndex()

        int savedLevelIndex = _snapshotManager.GetLevelIndex();

        TryLoadByIndex(savedLevelIndex);

    }


    public void TryLoadByIndex(int levelIndex)
    {
        if (_levelObjects.Count - 1 > levelIndex)
        {
            GameObject prefab = _levelObjects[levelIndex];
            GameObject.Instantiate(prefab, gameObject.transform);
            _messageSystem.LevelEvents.StartLevel();
        }
        else
        {
            _messageSystem.LevelEvents.LastLevelReached();
        }
           
    }


    private void OnDestroy()
    {
        _messageSystem.UIEvents.OnStartButtonClickEvent -= OnStartButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished -= OnLevelFinished;
    }

}
