using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreManager : MonoBehaviour
{
    public bool isLocked;

    public ItemManager currentPlayer;
    public int coins;
    public List<ItemManager> items = new List<ItemManager>();

    int playerNum;
    private void Start()
    {
        LoadItem();
    }

    void LoadItem()
    {
        if(PlayerPrefs.HasKey("Currentplayer"))
        {
            playerNum = PlayerPrefs.GetInt("Currentplayer");
        }
        else
        {
            PlayerPrefs.SetInt("Currentplayer", 0);
            playerNum = PlayerPrefs.GetInt("Currentplayer");
        }

        if (PlayerPrefs.HasKey("Coin"))
        {
            coins = PlayerPrefs.GetInt("Coin");
        }
        else
        {
            PlayerPrefs.SetInt("Coin", 0);
            playerNum = PlayerPrefs.GetInt("Coin");
        }

        switch (playerNum)
        {
            case 0:
                {
                    UpdatePlayer(items[0]);
                    break;
                }
            case 1:
                {
                    UpdatePlayer(items[1]);
                    break;
                }
            case 2:
                {
                    UpdatePlayer(items[2]);
                    break;
                }
            case 3:
                {
                    UpdatePlayer(items[3]);
                    break;
                }
            case 4:
                {
                    UpdatePlayer(items[4]);
                    break;
                }
        }
    }

    /*void UpdatePlayer(ItemManager item)
    {
        Sprite tempSprite = currentPlayer.sprite;
        currentPlayer.sprite = item.image.sprite;
        GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = item.image.sprite;
        item.image.sprite = tempSprite;
        item.isLocked = false;
        item.coins.SetActive(false);
        PlayerPrefs.SetInt("Currentplayer", item.itemNumber);
    }*/

    public void Purchase(ItemManager item)
    {
        if(item.isLocked)
        {
            if (item.coinsToUnlock <= coins)
            {
                coins -= item.coinsToUnlock;
                UpdatePlayer(item);
            }
            else
            {
                Debug.Log("Not Enough coins");
            }
            
        }
        else
        {
            UpdatePlayer(item);
        }
    }

    void UpdatePlayer(ItemManager item)
    {
        GameManager.instance.player.GetComponent<SpriteRenderer>().sprite = item.image.sprite;
        item.correct.SetActive(true);
        item.coins.SetActive(false);
        item.GetComponent<Button>().enabled = false;
        currentPlayer.GetComponent<Button>().enabled = true; 
        currentPlayer.coins.SetActive(true);
        currentPlayer.correct.SetActive(false);
        Vector3 pos = currentPlayer.GetComponent<RectTransform>().localPosition;
        currentPlayer.GetComponent<RectTransform>().localPosition = item.GetComponent<RectTransform>().localPosition;
        item.GetComponent<RectTransform>().localPosition = pos;

        PlayerPrefs.SetInt("Currentplayer", item.itemNumber);

        ItemManager tempItem = currentPlayer;
        currentPlayer = item;
        item = tempItem;
    }
    
}
