using UnityEngine.Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class GameLoopManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameConfig_SO _gameConfig;
    [SerializeField] private EndGameUI _endGameUI;
    [SerializeField] private GameTypeEnum _gameType;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private TextMeshPro _timerDisplay;
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _gameWinText; 
    [SerializeField] private GameObject _gameLoseText; 

    private AudioSource soundEffect;

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
        _player.GetComponent<DynamicMoveProvider>().enabled = false;
        _player.transform.position = new Vector3(0.194f, -0.807f, 4.122f);
        WeaponSelector sel = GameObject.FindObjectOfType<WeaponSelector>();
        
        if(_gameType == GameTypeEnum.Sword){
            sel.SelectSword();
        }
        else if(_gameType == GameTypeEnum.Shield){
            sel.SelectShield();
        }
        else if(_gameType == GameTypeEnum.Staff){
            sel.SelectStaff();
        }

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
        soundEffect = _gameLoseText.GetComponent<AudioSource>();
        soundEffect.Play();
        OnEndGame?.Invoke();
        _endGameUI.Activate(false);
        _gameLoseText.SetActive(true);
        _started = false;
    }

    public void Restart()
    {
        _currentTime = 0.0f;
        _endGameUI.Deactivate();
        OnRestart?.Invoke();
        _started = true;
        _gameWinText.SetActive(false);
        _gameLoseText.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Lobby 1");
    }
    #endregion

    #region PrivateMethods
    public void WinGame()
    {
        
        _spawner.Stop();
        _gameWinText.SetActive(true);
        OnEndGame?.Invoke();
        soundEffect = _gameWinText.GetComponent<AudioSource>();
        soundEffect.Play();
        PlayerPrefs.SetInt(_gameType == GameTypeEnum.Sword ?
                            "Sword" : _gameType == GameTypeEnum.Shield ?
                            "Shield" : "Staff", 1);
        _endGameUI.Activate(true);
        _started = false;
    }
    #endregion
}
