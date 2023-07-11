using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public TextMeshProUGUI level;
    public static MenuScript ms;
    public void LoadLevel()
    {
        if (Object.ReferenceEquals(null, Constants.GetValueInMemory("armorBool")))
        {
            Constants.SetValueInMemory("armorBool", 0);
        }
        else if (Constants.GetValueInMemory("armorBool") == 1 && Constants.GetValueInMemory("life")== 1)
        {
            PlayerInfos.pi.GetLife(1);
        }
        SceneManager.LoadScene(1);
    }
    public void level2()
    {
        //level.text = "Level 2";
    }

    public void LoadShop()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        ResetValuesInMemory();
        Application.Quit();
    }
    public void ResetGame()
    {
        ResetValuesInMemory();
        SceneManager.LoadScene(0);
    }
    public void ResetValuesInMemory()
    {
        Constants.SetValueInMemory("gold", 0);
        Constants.SetValueInMemory("xp", 0);
        Constants.SetValueInMemory("newWeaponBool", 0);
        Constants.SetValueInMemory("armorBool", 0);
        Constants.SetValueInMemory("Score", 0);
        Constants.SetValueInMemory("MaxScore", 0);
        Constants.SetValueInMemory("life", Constants.nbLives);
        Constants.SetValueInMemory("DashActivated", 0);
        Constants.SetValueInMemory("Level1", 0);
        Constants.SetValueInMemory("xpLevel", 0);
        Constants.SetValueInMemory("increaseSpeed", 0);
        Constants.canonSpeedMovement = 6;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (Object.ReferenceEquals(null, Constants.GetValueInMemory("Level1")))
        {
            Constants.SetValueInMemory("Level1", 0);
        }
        if (Constants.GetValueInMemory("Level1") == 1)
        {
            level2();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
