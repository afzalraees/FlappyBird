using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;

public class UIManager : MonoBehaviour
{
    public GameObject playButton;
    public Transform bg;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalScore;
    public GameObject gameOverScreen, storeScreen, recordScreen, homeScreen;
    // Start is called before the first frame update

    private void Awake()
    {
        
    }

    void Start()
    {

    }

    public void PlayGameUI()
    {
        OpenScreen(null);
        score.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        GameManager.instance.gameOver(finalScore);
    }

    public void OpenScreen(GameObject screen)
    {
        gameOverScreen.SetActive(false);
        homeScreen.SetActive(false);
        recordScreen.SetActive(false);
        storeScreen.SetActive(false);
        if(screen!=null)
        {
            screen.SetActive(true);
        }        
    }

    public void ResetUI()
    {
        score.text = 0.ToString();
    }
}
