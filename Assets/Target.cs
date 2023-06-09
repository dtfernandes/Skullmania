using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float width, height;

    public float Width => width;
    public float Height => height;

    [SerializeField]
    private GameObject[] lives;

    private int livesNumb = 3;

    [SerializeField]
    private GameObject gameOver;
    [SerializeField]
    private GameLoopManager gameLoop;
    [SerializeField]
    private Spawner spawner;
    [SerializeField]
    private GameObject timer;

    private Animator heartAnimator;
    private AudioSource soundEffect;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skull"))
        {
            livesNumb--;
            heartAnimator = lives[livesNumb].GetComponent<Animator>();
            heartAnimator.SetTrigger("LoseHeart");
            soundEffect = lives[livesNumb].GetComponent<AudioSource>();
            soundEffect.Play();
            //lives[livesNumb].SetActive(false);

            if (livesNumb == 0)
            {
                Die();
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void Die()
    {
        gameOver.SetActive(true);
        gameLoop.GameOver();
        spawner.Stop();
        timer.SetActive(false);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0.1f));
    }
}
