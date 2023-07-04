using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuScript : MonoBehaviour
{
    public void LoadLevel()
    {
        if (Object.ReferenceEquals(null, PlayerPrefs.GetInt("armorBool")))
        {
            PlayerPrefs.SetInt("armorBool", 0);
        }
        else if (PlayerPrefs.GetInt("armorBool") == 1 && PlayerPrefs.GetInt("life") == 1)
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
        PlayerPrefs.SetInt("gold", 0);
        PlayerPrefs.SetInt("newWeaponBool", 0);
        PlayerPrefs.SetInt("armorBool", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("MaxScore", 0);
        PlayerPrefs.SetInt("life", 1);
        PlayerPrefs.SetInt("DashActivated", 0);
        Application.Quit();
    }
    public void ResetGame()
    {
        PlayerPrefs.SetInt("gold", 0);
        PlayerPrefs.SetInt("newWeaponBool", 0);
        PlayerPrefs.SetInt("armorBool", 0);
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("MaxScore", 0);
        PlayerPrefs.SetInt("life", 1);
        PlayerPrefs.SetInt("DashActivated", 0);
        SceneManager.LoadScene(0);
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
