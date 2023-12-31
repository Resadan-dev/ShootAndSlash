using Assets.Scripts;
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
    public TextMeshProUGUI xp;
    public TextMeshProUGUI xpLevel;
    public int scoreInt = 0;
    public int maxScoreInt = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (Constants.GetValueInMemory("Level1") == 1)
        {
            int gold = Constants.GetValueInMemory("gold");
            Constants.SetValueInMemory("gold", gold + 1000);
        }
        int goldInt = Constants.GetValueInMemory("gold");
        gold.text = "Gold : " + goldInt;

        int xpInt = Constants.GetValueInMemory("xp");
        xp.text = "XP : " + xpInt;

        int xpLevelInt = Constants.GetValueInMemory("xpLevel");
        xpLevel.text = "XP level : " + xpLevelInt;

        int scoreRecorded = Constants.GetValueInMemory("Score");
        print("scoreRecorded : " + scoreRecorded);
        int maxScoreRecorded = Constants.GetValueInMemory("MaxScore");
        print("maxScoreRecorded : " + maxScoreRecorded);
        score.text = "Previous score : " + scoreRecorded;
        if (scoreRecorded > maxScoreRecorded || maxScoreRecorded == 0)
        {
            print("ici");
            Constants.SetValueInMemory("MaxScore", scoreRecorded);
            maxScore.text = "Your best score : " + scoreRecorded;
        }
        else maxScore.text = "Your best score : " + maxScoreRecorded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
