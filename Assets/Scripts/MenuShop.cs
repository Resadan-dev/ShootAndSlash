using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuShop : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI xpLevelText;
    public bool IsnewWeapon = false;
    public bool IsnewArmor = false;
    public GameObject Shield;
    public static MenuShop ms;
    private void Awake()
    {
        if (Constants.GetValueInMemory("newWeaponBool") == 1)
        {
            GameObject btn = GameObject.Find("AddWeaponButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
        }
        if (Constants.GetValueInMemory("armorBool") == 1)
        {
            GameObject btn = GameObject.Find("ShieldButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
        }
        if (Constants.GetValueInMemory("increaseSpeed") == 1)
        {
            GameObject btn = GameObject.Find("IncreaseSpeed");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
        }
        ms = this;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void newWeapon ()
    {
        int gold = Constants.GetValueInMemory("gold");
        if  (gold >= Constants.newWeaponPrice)
        {
            Constants.SetValueInMemory("gold", gold - Constants.newWeaponPrice);
            GameObject btn = GameObject.Find("AddWeaponButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
            Constants.SetValueInMemory("newWeaponBool", 1);
            IsnewWeapon = true;
            GameObject btnBack = GameObject.Find("BackToMenuButton");
            Button btnBackButton = btnBack.GetComponent<Button>();
            btnBackButton.Select();
        }
        gold = Constants.GetValueInMemory("gold");
        goldText.text = gold.ToString();
    }
    public void increaseSpeed()
    {
        int xpLevel = Constants.GetValueInMemory("xpLevel");
        if (xpLevel >= Constants.increaseSpeed)
        {
            GameObject btn2 = GameObject.Find("IncreaseSpeed");
            Button imgButton = btn2.GetComponent<Button>();
            imgButton.interactable = false;
            Constants.SetValueInMemory("increaseSpeed", 1);
            GameObject btnBack = GameObject.Find("BackToMenuButton");
            Button btnBackButton = btnBack.GetComponent<Button>();
            btnBackButton.Select();
            float speed = Constants.canonSpeedMovement;
            speed = speed +(speed * 0.5f);
            Constants.canonSpeedMovement = speed;
        }
    }

    public void oneShield()
    {
        int gold = Constants.GetValueInMemory("gold");
        if (gold >= Constants.armorPrice)
        {
            Constants.SetValueInMemory("gold", gold - Constants.armorPrice);
            GameObject btn = GameObject.Find("ShieldButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
            int life = Constants.GetValueInMemory("life");
            Constants.SetValueInMemory("life", life + 1);
            Constants.SetValueInMemory("armorBool", 1);
            IsnewArmor = true;
            GameObject btnBack = GameObject.Find("BackToMenuButton");
            Button btnBackButton = btnBack.GetComponent<Button>();
            btnBackButton.Select();
            Renderer renderer = Shield.GetComponent<Renderer>();
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            renderer.sharedMaterial.color = new Color32(157, 197, 227, 155);
        }
        gold = Constants.GetValueInMemory("gold");
        goldText.text = gold.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        int gold = Constants.GetValueInMemory("gold");
        goldText.text = gold.ToString();

        int xpLevel = Constants.GetValueInMemory("xpLevel");
        xpLevelText.text = xpLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Fire2") != 0)
        {
            SceneManager.LoadScene(0);
        }
    }
}
