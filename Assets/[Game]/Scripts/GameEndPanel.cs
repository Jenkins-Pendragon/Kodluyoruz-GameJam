using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameEndPanel : MonoBehaviour
{
    [SerializeField] private GameObject successPanel, failPanel;
    private void OnEnable()
    {
        EventManager.OnLevelFailed.AddListener(LevelFail);
        EventManager.OnLevelSuccesed.AddListener(levelSuccess);
    }
    private void OnDisable()
    {
        EventManager.OnLevelFailed.RemoveListener(LevelFail);
        EventManager.OnLevelSuccesed.RemoveListener(levelSuccess);
    }
    private void LevelFail()
    {
        failPanel.gameObject.SetActive(true);
        successPanel.gameObject.SetActive(false);
    }
    private void levelSuccess()
    {
        failPanel.gameObject.SetActive(false);
        successPanel.gameObject.SetActive(true);
    }

    #region BUTTONS
    public void NextLevelButton()
    {
        LevelManager.Instance.LevelUp();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartLevelButton()
    {

    }
    #endregion
}
