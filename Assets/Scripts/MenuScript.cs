using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
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
        Constants.SetValueInMemory("newWeaponBool", 0);
        Constants.SetValueInMemory("armorBool", 0);
        Constants.SetValueInMemory("Score", 0);
        Constants.SetValueInMemory("MaxScore", 0);
        Constants.SetValueInMemory("life", 1);
        Constants.SetValueInMemory("DashActivated", 0);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
