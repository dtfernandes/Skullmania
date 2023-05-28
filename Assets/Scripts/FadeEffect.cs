using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using System;

public class FadeEffect : MonoBehaviour
{
    #region Variables
    [Header("Association")]
    [SerializeField] private Image _fadeImage;
    [Header("Config")]
    [SerializeField] private Color _fadeColor;
    [SerializeField] private float _fadeDuration;

    private Action _fadeCompleteCallback;
    #endregion

    #region PublicMethods
    public void FadeIn(Action onComplete = null)
    {
        _fadeCompleteCallback = onComplete;

        StartCoroutine(DoFadeIn());
    }
    #endregion

    #region PrivateMethods
    private IEnumerator DoFadeIn()
    {
        _fadeImage.color = _fadeColor;
        _fadeImage.gameObject.SetActive(true);

        float elapsedTime = 0;
        while (elapsedTime < _fadeDuration)
        {
            float alpha = Mathf.Lerp(0f, 1f, elapsedTime / _fadeDuration);
            _fadeImage.color = new Color(_fadeColor.r, _fadeColor.g, _fadeColor.b, alpha);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _fadeCompleteCallback?.Invoke();
    }
    #endregion
}
