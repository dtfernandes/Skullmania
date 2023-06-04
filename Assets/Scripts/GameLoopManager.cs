using UnityEngine.Events;
using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameConfig_SO _gameConfig;

    private float _currentTime;
    private float _endTime;
    private bool _started;

    public UnityEvent OnEndGame;
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
                EndGame();
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
        //Display UI to restart or main menu
    }
    #endregion

    #region PrivateMethods
    private void EndGame()
    {
        OnEndGame?.Invoke();
        //Record that finished the game on player prefs
        //UI that finished the game and go back to main menu
    }
    #endregion
}
