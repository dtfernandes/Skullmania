using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLoopManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameConfig_SO _gameConfig;
    [SerializeField] private EndGameUI _endGameUI;
    [SerializeField] private GameTypeEnum _gameType;

    public float _currentTime;
    public float _endTime;
    private bool _started;

    public UnityEvent OnEndGame;
    public UnityEvent OnRestart;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _endTime = _gameConfig.SurvivalTime;
        _currentTime = 0.0f;
        _started = true;
    }

    private void Update()
    {
        if (_started)
        {
            _currentTime += Time.deltaTime;
            if (_currentTime >= _endTime)
                WinGame();
        }
    }
    #endregion

    #region PubicMethods
    public void StartLoop()
    {
        _started = true;
    }

    public void GameOver()
    {
        OnEndGame?.Invoke();
        _endGameUI.Activate(false);
    }

    public void Restart()
    {
        _currentTime = 0.0f;
        _endGameUI.Deactivate();
        OnRestart?.Invoke();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby 1");
    }
    #endregion

    #region PrivateMethods
    private void WinGame()
    {
        OnEndGame?.Invoke();
        PlayerPrefs.SetInt(_gameType == GameTypeEnum.Sword ?
                            "Sword" : _gameType == GameTypeEnum.Shield ?
                            "Shield" : "Magic", 1);
        _endGameUI.Activate(true);
    }
    #endregion
}
