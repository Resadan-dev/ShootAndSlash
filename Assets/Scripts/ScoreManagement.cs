using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManagement : MonoBehaviour
{
    public TextMeshProUGUI score;
    public TextMeshProUGUI maxScore;
    public TextMeshProUGUI gold;
    public int scoreInt = 0;
    public int maxScoreInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        int goldInt = PlayerPrefs.GetInt("gold");
        gold.text = "Gold : " + goldInt;
        int scoreRecorded = PlayerPrefs.GetInt("Score");
        print("scoreRecorded : " + scoreRecorded);
        int maxScoreRecorded = PlayerPrefs.GetInt("MaxScore");
        print("maxScoreRecorded : " + maxScoreRecorded);
        score.text = "Previous score : " + scoreRecorded;
        if (scoreRecorded > maxScoreRecorded || maxScoreRecorded == 0)
        {
            print("ici");
            PlayerPrefs.SetInt("MaxScore", scoreRecorded);
            maxScore.text = "Your best score : " + scoreRecorded;
        }
        else maxScore.text = "Your best score : " + maxScoreRecorded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
