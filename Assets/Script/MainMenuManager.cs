using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [Header("Main Menu Panel List")]
    public GameObject MainPanel;
    public GameObject HTPPanel;
    public GameObject TimerPanel;
    public GameObject BallSelectionPanel;

    // Start is called before the first frame update
    void Start()
    {
        MainPanel.SetActive(true);
        HTPPanel.SetActive(false);
        TimerPanel.SetActive(false);
        BallSelectionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SinglePlayerButton()
    {
        GameData.instance.isSinglePlayer = true;
        TimerPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void MultiplePlayerButton()
    {
        GameData.instance.isSinglePlayer = false;
        TimerPanel.SetActive(true);
        SoundManager.instance.UIClickSfx();
    }

    public void BackButton()
    {
        HTPPanel.SetActive(false);
        TimerPanel.SetActive(false);
        BallSelectionPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void SetTimerButton(float Timer)
    {
        GameData.instance.gameTimer = Timer;
        BallSelectionPanel.SetActive(true);
        TimerPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void BallButton1()
    {
        GameData.instance.ball = 1;
        HTPPanel.SetActive(true);
        BallSelectionPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void BallButton2()
    {
        GameData.instance.ball = 2;
        HTPPanel.SetActive(true);
        BallSelectionPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void BallButton3()
    {
        GameData.instance.ball = 3;
        HTPPanel.SetActive(true);
        BallSelectionPanel.SetActive(false);
        SoundManager.instance.UIClickSfx();
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("2. Gameplay");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
