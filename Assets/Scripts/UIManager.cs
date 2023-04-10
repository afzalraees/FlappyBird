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
    public GameObject gameOverScreen;

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

    public void PlayGame()
    {
        playButton.SetActive(false);
        Time.timeScale = 1.0f;
    }
    void Start()
    {
        Time.timeScale = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
