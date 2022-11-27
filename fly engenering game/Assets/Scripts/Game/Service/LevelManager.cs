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
        //œŒ—ÃŒ“–≈“‹ ¬ —Œ’–¿Õ≈Õ»ﬂ » ¬€¡–¿“‹ »« —œ»— ¿ Õ”∆Õ€… ”–Œ¬≈Õ‹! SnapshotManager.GEtIndex()

        int savedLevelIndex = Context.Inctance.GetSnapshotManager().GetLevelIndex();

        GameObject prefab = _levelObjects[savedLevelIndex];
        
        GameObject.Instantiate(prefab, gameObject.transform);
    }

    private void OnDestroy()
    {
        Context.Inctance.GetMessageSystem().UIEvents.OnStartButtonClickEvent -= OnStartButtonClick;
    }

}
