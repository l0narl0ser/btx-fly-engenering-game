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
        Context.Inctance.GetMessageSystem().UIEvents.OnStartButtonClickEvent += OnStartButtonClick;
    }

    private void OnStartButtonClick()
    {
        //онялнрперэ б янупюмемхъ х бшапюрэ хг яохяйю мсфмши спнбемэ! SnapshotManager.GEtIndex()

        int savedLevelIndex = Context.Inctance.GetSnapshotManager().GetLevelIndex();

        GameObject prefab = _levelObjects[savedLevelIndex];
        
        GameObject.Instantiate(prefab, gameObject.transform);
    }
}
