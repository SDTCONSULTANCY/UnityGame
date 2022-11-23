using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action onFail;
    public static event Action onSuccess;

    public static void InvokeFail() => onFail?.Invoke();
    public static void InvokeSuccess() => onSuccess?.Invoke();

    [SerializeField] GameObject failScreen;
    [SerializeField] GameObject winScreen;

    private void OnEnable()
    {
        onFail += OnFail;
        onSuccess += OnWin;
    }

    private void OnDisable()
    {
        onFail -= OnFail;
        onSuccess -= OnWin;
    }

    void OnFail()
    {
        failScreen.SetActive(true);
    }

    void OnWin()
    {
        winScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
