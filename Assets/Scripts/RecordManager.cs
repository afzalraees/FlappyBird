using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class RecordManager : MonoBehaviour
{
    public int record, totalAttempts;
    public TextMeshProUGUI recordTxt, totalAttemptsTxt;
    // Start is called before the first frame update
    void Start()
    {
        LoadRecord();
    }

    void LoadRecord()
    {
        if (PlayerPrefs.HasKey("Record"))
        {
            record = PlayerPrefs.GetInt("Record");
        }
        else
        {
            PlayerPrefs.SetInt("Record", record);
        }

        if (PlayerPrefs.HasKey("TotalAttempts"))
        {
            totalAttempts = PlayerPrefs.GetInt("TotalAttempts");
        }
        else
        {
            PlayerPrefs.SetInt("TotalAttempts", totalAttempts);
        }
    }
    public void Updaterecord(int score)
    {
        record = score;
        recordTxt.text = record.ToString();
    }

    public void UpdateTotalAttempts()
    {
        totalAttempts++;
        totalAttemptsTxt.text = totalAttempts.ToString();   
    }
}
