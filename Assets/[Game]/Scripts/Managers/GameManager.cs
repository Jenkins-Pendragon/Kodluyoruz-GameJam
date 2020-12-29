using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private bool isGameStarted;
    public bool IsGameStarted { get { return isGameStarted; } private set { isGameStarted = value; } }


    private void OnEnable()
    {
        EventManager.OnLevelFailed.AddListener(EndGame);
        EventManager.OnLevelSuccesed.AddListener(EndGame);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFailed.RemoveListener(EndGame);
        EventManager.OnLevelSuccesed.RemoveListener(EndGame);
    }

    public void StartGame()
    {
        if (IsGameStarted)
            return;

        IsGameStarted = true;
        EventManager.OnGameStarted.Invoke();
    }

    public void EndGame()
    {
        if (!IsGameStarted)
            return;

        IsGameStarted = false;
        EventManager.OnGameEnd.Invoke();        
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

}
