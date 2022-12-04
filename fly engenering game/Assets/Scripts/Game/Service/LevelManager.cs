using Assets.Scripts.Core;
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
        _messageSystem = Context.Inctance.GetMessageSystem();
        _snapshotManager = Context.Inctance.GetSnapshotManager();
        _messageSystem.UIEvents.OnStartButtonClickEvent += OnStartButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished += OnLevelFinished;
    }

    private void OnLevelFinished()
    {
        NextLevel();
    }

    private void NextLevel()
    {
        int savedLevelIndex = _snapshotManager.GetLevelIndex();
        savedLevelIndex++;
        _snapshotManager.SetLevelIndex(savedLevelIndex);
        _snapshotManager.Save();
        LoadLevelByIndex(savedLevelIndex);
    }

    private void OnStartButtonClick()
    {
        //œŒ—ÃŒ“–≈“‹ ¬ —Œ’–¿Õ≈Õ»ﬂ » ¬€¡–¿“‹ »« —œ»— ¿ Õ”∆Õ€… ”–Œ¬≈Õ‹! SnapshotManager.GEtIndex()

        int savedLevelIndex = _snapshotManager.GetLevelIndex();

        LoadLevelByIndex(savedLevelIndex);

    }


    public void LoadLevelByIndex(int levelIndex)
    {
        GameObject prefab = _levelObjects[levelIndex];

        GameObject.Instantiate(prefab, gameObject.transform);
        _messageSystem.LevelEvents.StartLevel();
    }


    private void OnDestroy()
    {
        _messageSystem.UIEvents.OnStartButtonClickEvent -= OnStartButtonClick;
        _messageSystem.LevelEvents.OnLevelFinished -= OnLevelFinished;
    }

}
