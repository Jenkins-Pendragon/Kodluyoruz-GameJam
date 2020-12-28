using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelManager : Singleton<LevelManager>
{
    public LevelData LevelData;
    public Level CurrentLevel { get { return (LevelData.Levels[LevelIndex]); } }


    private void Awake()
    {
        PlayerPrefs.SetInt("LastLevel", 0);
    }
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
        PlayerPrefs.SetInt("LastLevel", PlayerPrefs.GetInt("LastLevel") +1 );
    }
}

