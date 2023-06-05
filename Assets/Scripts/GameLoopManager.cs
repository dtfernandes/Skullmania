using UnityEngine.Events;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameConfig_SO _gameConfig;
    [SerializeField] private GameObject[] _endGameUI;
    [SerializeField] private GameTypeEnum _gameType;

    private float _currentTime;
    private float _endTime;
    private bool _started;

    public UnityEvent OnEndGame;
    public UnityEvent OnRestart;
    #endregion

    #region UnityMethods
    private void Start()
    {
        _endTime = _gameConfig.SurvivalTime;
        _currentTime = 0.0f;
        _started = false;
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
        _endGameUI[1].SetActive(true);
    }

    public void Restart()
    {
        _currentTime = 0.0f;
        _endGameUI[0].SetActive(false);
        _endGameUI[1].SetActive(false);
        OnRestart?.Invoke();
    }
    #endregion

    #region PrivateMethods
    private void WinGame()
    {
        OnEndGame?.Invoke();
        PlayerPrefs.SetInt(_gameType == GameTypeEnum.Sword ?
                            "Sword" : _gameType == GameTypeEnum.Shield ?
                            "Shield" : "Magic", 1);
        _endGameUI[0].SetActive(true);
    }
    #endregion
}
