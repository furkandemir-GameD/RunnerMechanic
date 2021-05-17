using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviourSingleton<UIManager>
{
    [SerializeField] private GameObject winButton;
    [SerializeField] private GameObject failButton;
    [SerializeField] private GameObject playButton;
    [SerializeField] private Image fillAmount;
    [SerializeField] private GameObject fillAmountMain;

    private void OnEnable()
    {
        GameManager.OnGameStateChange += GameStart;
    }

    private void OnDisable()
    {
        GameManager.OnGameStateChange = GameStart;

    }
    private void GameStart(GameManager.GameStates state)
    {
        if (state==GameManager.GameStates.GameFail)
        {
            FailCondiation();
        }
        if (state == GameManager.GameStates.GamePlayRun)
        {
            StartedGame();
        }
        if (state == GameManager.GameStates.GameWin)
        {
            WinCondiation();
        }
        if (state == GameManager.GameStates.GamePlayPaint)
        {
            StartPaint();
        }
    }
    public void FillAmount(float currentValue)
    {
        fillAmount.fillAmount = currentValue;
    }
    public void StartGame()
    {
        fillAmountMain.SetActive(false);
        playButton.SetActive(false);
        GameManager.Instance.StartGame();
    }
    public void StartedGame()
    {
    
    }
    public void StartPaint()
    {
        fillAmountMain.SetActive(true);
    }
    public void FailCondiation()
    {
        failButton.SetActive(true);
    }
    public void FailGame()
    {
        failButton.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void WinCondiation()
    {
        winButton.SetActive(true);
    }
    public void WinGame()
    {
        SceneManager.LoadScene(0);
        winButton.SetActive(false);
    }
}
