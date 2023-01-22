using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioClip uiButton;
    public AudioClip ballBounce;
    public AudioClip goal;
    public AudioClip gameOver;

    private AudioSource audio1;

    private void Awake()
    {
        if (instance != null)
            Destroy(gameOver);
        else
            instance = this;

        audio1 = GetComponent<AudioSource>();
    }

    public void UIClickSfx()
    {
        audio1.PlayOneShot(uiButton);
    }

    public void BallBounceSfx()
    {
        audio1.PlayOneShot(ballBounce);
    }

    public void GoalSfx()
    {
        audio1.PlayOneShot(goal);
    }

    public void GameOverSfx()
    {
        audio1.PlayOneShot(gameOver);
    }
}
