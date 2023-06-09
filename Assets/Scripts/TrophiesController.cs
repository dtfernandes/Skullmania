using UnityEngine;

public class TrophiesController : MonoBehaviour
{
    [SerializeField] private GameObject[] _trophies;
    private int wins;

    private AudioSource soundEffect;
    private void Start()
    {
        wins = 0;
        if (PlayerPrefs.GetInt("Shield") == 1)
        {
            _trophies[0].SetActive(true);
            wins++;
        }

        if (PlayerPrefs.GetInt("Staff") == 1)
        {
            _trophies[1].SetActive(true);
            wins++;
        }

        if (PlayerPrefs.GetInt("Sword") == 1)
        {
            _trophies[2].SetActive(true);
            wins++;
        }

        if (wins == 3)
        {
            soundEffect = this.GetComponent<AudioSource>();
            soundEffect.Play();
        }
    }
}
