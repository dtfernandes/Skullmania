using UnityEngine;

public class TrophiesController : MonoBehaviour
{
    [SerializeField] private GameObject[] _trophies;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Shield") == 1)
            _trophies[0].SetActive(true);
        if (PlayerPrefs.GetInt("Staff") == 1)
            _trophies[1].SetActive(true);
        if (PlayerPrefs.GetInt("Sword") == 1)
            _trophies[2].SetActive(true);
    }
}
