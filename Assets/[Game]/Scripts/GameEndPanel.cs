using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject successPanel, failPanel;
    private void OnEnable()
    {
        EventManager.OnLevelFailed.AddListener(LevelFail);
        EventManager.OnLevelSuccesed.AddListener(LevelSuccess);
    }
    private void OnDisable()
    {
        EventManager.OnLevelFailed.RemoveListener(LevelFail);
        EventManager.OnLevelSuccesed.RemoveListener(LevelSuccess);
    }
    private void LevelFail()
    {
        failPanel.gameObject.SetActive(true);
        successPanel.gameObject.SetActive(false);
    }
    private void LevelSuccess()
    {
        failPanel.gameObject.SetActive(false);
        successPanel.gameObject.SetActive(true);
    }

    private void DisableAllPanels()
    {
        successPanel.SetActive(false);
        failPanel.SetActive(false);
    }

    #region BUTTONS
    IEnumerator LevelButtonCo()
    {
        yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        yield return SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        SceneManager.SetActiveScene(SceneManager.GetSceneAt(2));
        GameManager.Instance.StartGame();

        DisableAllPanels();

    }

    public void NextLevelButton()
    {
        LevelManager.Instance.LevelUp();
        StartCoroutine(LevelButtonCo());
    }
    public void RestartLevelButton()
    {
        StartCoroutine(LevelButtonCo());
    }
    #endregion
}
