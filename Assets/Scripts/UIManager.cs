using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public GameObject playButton;
    public Text score;
    public Text finalScore;
    public GameObject gameOverScreen, pauseScreen;
    public bool uiActive;

    public static UIManager instance;
    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        
    }



    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        pauseScreen.SetActive(true);
        StartCoroutine(StopPhysics());
        uiActive = true;
    }

    public void Continue()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        uiActive = false;
    }

    public void PlayGame()
    {
        playButton.SetActive(false);
        Time.timeScale = 1.0f;
        uiActive = false;
    }
    void Start()
    {
        Time.timeScale = 0.0f;
        uiActive = true;
    }

    IEnumerator StopPhysics()
    {
        yield return new WaitForSeconds(0.2f);
        Time.timeScale = 0.0f;
    }

    public void GameOver()
    {
        uiActive = true;
        finalScore.text = "Final Score: " + BirdManager.instance.score.ToString();
        gameOverScreen.SetActive(true);
        StartCoroutine(StopPhysics());
    }
}
