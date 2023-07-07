using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Image timerBar;
    public float MaxTime = Constants.MaxTime;
    float timeLeft;
    private int currentLevel = 1;
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = MaxTime;
        PlayerInfos.pi.levelTxt.text = "Level : " + currentLevel;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= MaxTime)
        {
            timeLeft -= Time.deltaTime;
            float percent = 1 - (timeLeft / MaxTime);
            timerBar.fillAmount = 1 - (timeLeft / MaxTime);
            if (timeLeft <= 0)
            {
                timeLeft = MaxTime;
                currentLevel += 1;
                Constants.speed += 0.8f;
                PlayerInfos.pi.levelTxt.text = "Level : " + currentLevel;
            }
        }
        
    }
}
