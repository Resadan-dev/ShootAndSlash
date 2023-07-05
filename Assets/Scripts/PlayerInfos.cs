using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfos : MonoBehaviour
{
    public static PlayerInfos pi;
    public int score = 0;
    public int gold;
    public int life;
    public TextMeshProUGUI scoreTxt;
    public TextMeshProUGUI goldTxt;
    public TextMeshProUGUI lifeTxt;
    public TextMeshProUGUI DashcoolDown;
    public bool isGameOver = false;

    private void Awake()
    {
        pi = this; 
    }
    public void GetScore()
    {
        score++;
        scoreTxt.text = "Score : "+score.ToString();
    }
    public void GetGold(int amount)
    {
        int goldStored = Constants.GetValueInMemory("gold");
        gold = goldStored + amount;
        Constants.SetValueInMemory("gold", gold);
        goldTxt.text = "Gold : " + gold.ToString();
    }
    public void GetLife(int amount)
    {
        int lifeStored = Constants.GetValueInMemory("life");
        life = lifeStored + amount;
        Constants.SetValueInMemory("life", life);
        lifeTxt.text = "Life : " + life.ToString();
    }
    public void UpdateCoolDown(int nb)
    {
        DashcoolDown.text = "Dash cooldown : "+nb.ToString();
    }
    public void GameOver()
    {
        StartCoroutine(GameOvering());
    }
    public IEnumerator GameOvering()
    {
        isGameOver = true;
        scoreTxt.text = "GAME OVER";
        yield return new WaitForSeconds(0.5f);
        Constants.SetValueInMemory("Score", score);
        Constants.SetValueInMemory("DashActivated", 0);
        SceneManager.LoadScene(0);
    }


// Start is called before the first frame update
void Start()
    {
        goldTxt.text = "Gold : " + Constants.GetValueInMemory("gold");
        lifeTxt.text = "Life : " + Constants.GetValueInMemory("life");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
