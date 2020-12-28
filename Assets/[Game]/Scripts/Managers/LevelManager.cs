using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }

    public int LevelIndex
    {
        get
        {
            return PlayerPrefs.GetInt("LastLevel", 0);
        }
        set
        {
            if (value >= LevelData.Levels.Count)
                value = 0;

            PlayerPrefs.SetInt("LastLevel", value);
        }
    }
    public void LevelUp()
    {
        LevelIndex += 1;
        PlayerPrefs.SetInt("LastLevel", LevelIndex);
    }
}

