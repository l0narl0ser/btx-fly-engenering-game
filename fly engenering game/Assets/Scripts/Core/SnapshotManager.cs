using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapshotManager
{
    private const string LevelIndexKey = "levelIndex";
    private int _levelIndex;

    public void SetLevelIndex(int levlIndex)
    {
        _levelIndex = levlIndex;
    }
    public void Reset()
    {
        _levelIndex = 0;
        PlayerPrefs.DeleteAll();
    }

    public int GetLevelIndex()
    {
        return _levelIndex;
    }
    public void Save()
    {
        PlayerPrefs.SetInt(LevelIndexKey, _levelIndex);
        PlayerPrefs.Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(LevelIndexKey))
        {
            _levelIndex = PlayerPrefs.GetInt(LevelIndexKey);
        }
        else
        {
            _levelIndex = 0;
        }
    }
}
