using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager;
    public RecordManager recordManager;
    public StoreManager storeManager;
    public PlayerManager player;

    public int score;
    public GameObject pipes;
    public List<Transform> pipeList = new List<Transform>();
    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
            Destroy(this);
    }
    
    public void StartGame()
    {
        uiManager.PlayGameUI();
        player.gameObject.SetActive(true);
        pipes.SetActive(true);
        recordManager.UpdateTotalAttempts();
    }

    public void gameOver(TextMeshProUGUI finalScore)
    {
        player.gameObject.SetActive(false);
        pipes.SetActive(false);
        finalScore.text = score.ToString();
        if(score > recordManager.record)
        {
            recordManager.Updaterecord(score);
        }
        PlayerPrefs.SetInt("Coin", storeManager.coins);
    }

    public void RestartGame()
    {
        player.gameObject.SetActive(true);
        pipes.SetActive(true);
        player.transform.position = Vector3.zero;
        score = 0;
        float x = 0;
        for(int i = 0; i < pipeList.Count; i++)
        {
            x += 25;
            pipeList[i].localPosition = new Vector3(x, 0, 0);
        }
        uiManager.OpenScreen(null);
        uiManager.ResetUI();
    }
}
