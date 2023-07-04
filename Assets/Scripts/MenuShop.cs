using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuShop : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public bool IsnewWeapon = false;
    public bool IsnewArmor = false;
    public GameObject Shield;
    public static MenuShop ms;
    private void Awake()
    {
        if (PlayerPrefs.GetInt("newWeaponBool") == 1)
        {
            GameObject btn = GameObject.Find("AddWeaponButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
        }
        if (PlayerPrefs.GetInt("armorBool") == 1)
        {
            GameObject btn = GameObject.Find("ShieldButton");
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
        int gold = PlayerPrefs.GetInt("gold");
        if  (gold >= 00)
        {
            PlayerPrefs.SetInt("gold", gold - 0);
            GameObject btn = GameObject.Find("AddWeaponButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
            PlayerPrefs.SetInt("newWeaponBool", 1);
            IsnewWeapon = true;
            GameObject btnBack = GameObject.Find("BackToMenuButton");
            Button btnBackButton = btnBack.GetComponent<Button>();
            btnBackButton.Select();
        }
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = gold.ToString();
    }

    public void oneShield()
    {
        int gold = PlayerPrefs.GetInt("gold");
        if (gold >= 0)
        {
            PlayerPrefs.SetInt("gold", gold - 0);
            GameObject btn = GameObject.Find("ShieldButton");
            Button imgButton = btn.GetComponent<Button>();
            imgButton.interactable = false;
            PlayerPrefs.SetInt("life", 2);
            PlayerPrefs.SetInt("armorBool", 1);
            IsnewArmor = true;
            GameObject btnBack = GameObject.Find("BackToMenuButton");
            Button btnBackButton = btnBack.GetComponent<Button>();
            btnBackButton.Select();
            Renderer renderer = Shield.GetComponent<Renderer>();
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            renderer.sharedMaterial.color = new Color32(157, 197, 227, 155);
        }
        gold = PlayerPrefs.GetInt("gold");
        goldText.text = gold.ToString();
    }

    // Start is called before the first frame update
    void Start()
    {
        int gold = PlayerPrefs.GetInt("gold");
        goldText.text = gold.ToString();
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
