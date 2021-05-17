using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public static UnityAction OnGameStartRun;
    public static UnityAction OnGameStartPaint;
    public static UnityAction OnGameFail;
    public static UnityAction OnGameWin;
   


    public static UnityAction<GameStates> OnGameStateChange;

    private GameStates currentState = GameStates.LoadingLevel;
    public GameStates CurrentState
    {
        get
        {
            return currentState;
        }
        set
        {
            currentState = value;
            OnGameStateChange?.Invoke(value);
        }
    }

    private void Start()
    {
        CurrentState = GameStates.MainMenu;
        OnGameStateChange?.Invoke(GameStates.MainMenu);
    }

    public void StartGame()
    {
        OnGameStartRun?.Invoke();
        CurrentState = GameStates.GamePlayRun;
    }
    public void StartPaint()
    {
        OnGameStartPaint?.Invoke();
        CurrentState = GameStates.GamePlayPaint;
    }
    public void FailGame()
    {
        OnGameFail?.Invoke();
        CurrentState = GameStates.GameFail;
        //UIManager.Instance.FailCondiation();
    }

    public void WinGame()
    {
        OnGameWin?.Invoke();
        CurrentState = GameStates.GameWin;
        Debug.Log("Win !!");
        //UIManager.Instance.WinCondiation();
    }

    public enum GameStates
    {
        LoadingLevel,
        MainMenu,
        GamePlayRun,
        GamePlayPaint,
        GameFail,
        GameWin,
    }
}
