using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    public int score = 0;
    public int life = 1;
    public GameObject Shield;

    float cubesPivotDistance;
    Vector3 cubesPivot;
    private void OnTriggerEnter(Collider other)
    {
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
                    {
                        PlayerInfos.pi.GetGold(Constants.orangeCubeGold);
                        PlayerInfos.pi.GetXP(Constants.orangeCubeXP);
                        Destroy(gameObject);
                        Destroy(other.gameObject);
                    }
                    if (gameObject.tag == "redCube")
                    {
                        PlayerInfos.pi.GetGold(Constants.redCubeGold);
                        PlayerInfos.pi.GetXP(Constants.redCubeXP);
                        Destroy(gameObject);
                        Destroy(other.gameObject);
                    }
                    if (gameObject.tag == "greenCube")
                    {
                        PlayerInfos.pi.GetGold(Constants.greenCubeGold);
                        PlayerInfos.pi.GetXP(Constants.greenCubeXP);
                        Destroy(gameObject);
                        Destroy(other.gameObject);
                    }
                    if (gameObject.tag == "maxiCube")
                    {
                        PlayerInfos.pi.GetGold(Constants.greenCubeGold);
                        PlayerInfos.pi.GetXP(Constants.greenCubeXP);
                        Destroy(gameObject);
                        Destroy(other.gameObject);
                    }
                    if (gameObject.tag == "otherCube")
                    {
                        Destroy(other.gameObject);
                    }


                }
                else
                {
                    if (gameObject.tag == "orangeCube")
                    {
                        Color color = gameObject.GetComponent<Renderer>().material.color;
                        Color newColor = new Color(color.r, (float)(color.g +0.2), (float)(color.b +0.2));
                        gameObject.GetComponent<Renderer>().material.color = newColor;

                    }
                    if (gameObject.tag == "redCube")
                    {
                        Color color = gameObject.GetComponent<Renderer>().material.color;
                        Color newColor = new Color(color.r, (float)(color.g + 0.08), (float)(color.b + 0.08));
                        gameObject.GetComponent<Renderer>().material.color = newColor;
                    }
                    Destroy(other.gameObject);
                    life -= 1;
                }
            }
        }
    }
    public void SetOrangeCube()
    {
        life = Constants.orangeCubeLife;
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(255, 155, 0, 0);
        myRenderer.material.color = newColor;
        myRenderer.tag = "orangeCube";
    }
    public void SetRedCube()
    {
        life = Constants.redCubeLife;
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(255, 0, 0, 0);
        myRenderer.material.color = newColor;
        myRenderer.tag = "redCube";
    }
    public void SetBlackCube()
    {
        life = Constants.blackCubeLife;
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(0, 0, 0, 0);
        myRenderer.material.color = newColor;
        myRenderer.tag = "blackCube";
    }
    // Start is called before the first frame update
    void Start()
    {

        System.Random rand = new System.Random();
        Renderer myRenderer = GetComponent<Renderer>();
        if (rand.Next(0, 3) == 0 && myRenderer.tag != "maxiCube")
        {
            SetOrangeCube();
        }
        else if (rand.Next(0, 5) == 0 && myRenderer.tag != "maxiCube")
        {
            SetRedCube();
        }
        else if (rand.Next(0, 7) == 0 && myRenderer.tag != "maxiCube")
        {
            SetBlackCube();
        }
        if (myRenderer.tag == "maxiCube")
        {
            if (rand.Next(0, 3) == 0)
            {
                SetBlackCube();
            }
            else SetRedCube();
        }
        cubesPivotDistance = Constants.cubeSize * Constants.cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
