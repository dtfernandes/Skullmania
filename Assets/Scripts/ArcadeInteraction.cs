using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ArcadeInteraction : MonoBehaviour
{
    #region Variables
    [Header("Association")]
    [SerializeField] private GameObject _fadeEffectPrefab;

    [Header("Config")]
    [SerializeField] private string _sceneToSwitch;

    [SerializeField]
    private FadeEffect _fadeEffect;
    #endregion

    #region PublicMethods
    public void ActivateArcade()
    {
        //_fadeEffect = Instantiate(_fadeEffectPrefab, Vector3.zero, Quaternion.identity);

        FadeEffect fade = _fadeEffect;
        fade.FadeIn(() =>
        {
            StartCoroutine(LoadNewScene());
        });
    }
    #endregion

    #region PrivateMethods
    private IEnumerator LoadNewScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_sceneToSwitch, LoadSceneMode.Additive);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
    #endregion


    [SerializeField]
    private KeyCode debugButton;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (_fadeEffect == null)
        {
             Debug.Log("Beep");
            _fadeEffect = GameObject.FindObjectOfType<FadeEffect>();
        }

        if (Input.GetKeyDown(debugButton)) 
        {
            ActivateArcade();

        }
    }
}
