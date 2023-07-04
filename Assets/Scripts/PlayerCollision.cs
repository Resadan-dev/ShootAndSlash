using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int score = 0;
    public int life = 1;
    public int greenCubeGold = 10;
    public int OrangeCubeGold = 30;
    public GameObject Shield;
    private void OnTriggerEnter(Collider other)
    {
        int lifePlayer = PlayerPrefs.GetInt("life");
        if (other.gameObject == Shield)
        {
            print("OK");
        }
        else
        {
            if (other.gameObject.tag == "Bullet")
            {
                if (life == 1)
                {
                    PlayerInfos.pi.GetScore();
                    if (gameObject.tag == "orangeCube")
                        PlayerInfos.pi.GetGold(OrangeCubeGold);
                    else PlayerInfos.pi.GetGold(greenCubeGold);

                    Destroy(gameObject);
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                    life -= 1;
                }
            }
        }
    }
    public void SetOrangeCube()
    {
        life = 3;
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(255, 155, 0, 0);
        myRenderer.material.color = newColor;
        myRenderer.tag = "orangeCube";
    }
    public void SetRedCube()
    {
        life = 10;
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(255, 0, 0, 0);
        myRenderer.material.color = newColor;
        myRenderer.tag = "redCube";
    }
    // Start is called before the first frame update
    void Start()
    {

        System.Random rand = new System.Random();

        if (rand.Next(0, 3) == 0)
        {
            SetOrangeCube();
        }
        if (rand.Next(0,5) == 0)
        {
            SetRedCube();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
