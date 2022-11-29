using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    public static event Action onStart;
    public static event Action onFail;
    public static event Action onSuccess;
    static event Action onCoinsChange;

    public static void InvokeFail() => onFail?.Invoke();
    public static void InvokeSuccess() => onSuccess?.Invoke();

    [SerializeField] GameObject startScreen;
    [SerializeField] GameObject failScreen;
    [SerializeField] GameObject winScreen;

    [SerializeField] Text levetText;
    [SerializeField] Text gemText;


    static int current_level = 0;

    static int gems = 0;
    public static int Gems
    {
        get => gems;

        set
        {
            gems = value;
            onCoinsChange?.Invoke();
        }
    }

    public void LoadNextLevel()
    {
        current_level++;
        int index = current_level % SceneManager.sceneCountInBuildSettings;
        Time.timeScale = 1f;
        SceneManager.LoadScene(index);
    }

    private void Start()
    {
        levetText.text = (current_level + 1).ToString();
        Time.timeScale = 0;

        UpdateGems();
    }

    private void OnEnable()
    {
        onFail += OnFail;
        onSuccess += OnWin;
        onCoinsChange += UpdateGems;

    }

    private void OnDisable()
    {
        onFail -= OnFail;
        onSuccess -= OnWin;
        onCoinsChange -= UpdateGems;
    }

    void UpdateGems()
    {
        gemText.text = gems.ToString();
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        onStart?.Invoke();
        startScreen.SetActive(false);
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
