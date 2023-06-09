using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.XR.CoreUtils;

public class GameLoopManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameConfig_SO _gameConfig;
    [SerializeField] private EndGameUI _endGameUI;
    [SerializeField] private GameTypeEnum _gameType;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshPro _timerDisplay;
    [SerializeField] private GameObject _player;


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
        _started = true;
        _player = GameObject.FindObjectOfType<XROrigin>().gameObject;
        _player.transform.position = new Vector3(0.194f, -0.807f, 4.122f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            WinGame();
        if (Input.GetKeyDown(KeyCode.Escape))
            MainMenu();

        if (_started)
        {
            //Separate seconds and milliseconds
            float timeDifference = _endTime - _currentTime;
            int seconds = Mathf.FloorToInt(timeDifference);
            int milliseconds = Mathf.FloorToInt((timeDifference - seconds) * 1000);

            //Should format time as 00:00 but is not working :c 
            string formattedTime = string.Format("{0:00}:{1:00}", seconds, milliseconds);

            //Display timer
            _timerDisplay.text = formattedTime;

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
        _started = false;
    }

    public void Restart()
    {
        _currentTime = 0.0f;
        _endGameUI.Deactivate();
        OnRestart?.Invoke();
        _started = true;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby");
    }
    #endregion

    #region PrivateMethods
    private void WinGame()
    {
        _spawner.Stop();
        OnEndGame?.Invoke();
        PlayerPrefs.SetInt(_gameType == GameTypeEnum.Sword ?
                            "Sword" : _gameType == GameTypeEnum.Shield ?
                            "Shield" : "Magic", 1);
        _endGameUI.Activate(true);
        _started = false;
    }
    #endregion
}
