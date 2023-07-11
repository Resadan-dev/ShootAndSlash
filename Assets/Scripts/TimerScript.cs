using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public Image timerBar;
    public float MaxTime = Constants.MaxTime;
    float timeLeft;
    private int currentLevel = 1;
    public GameObject Endgame1;
    // Start is called before the first frame update
    void Start()
    {
        timerBar = GetComponent<Image>();
        timeLeft = MaxTime;
        PlayerInfos.pi.levelTxt.text = "Level : " + currentLevel;
        StartCoroutine(EndGame1());
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= MaxTime)
        {
            timeLeft -= Time.deltaTime;
            timerBar.fillAmount = 1 - (timeLeft / MaxTime);
            if (timeLeft <= 0)
            {
                timeLeft = MaxTime;
                currentLevel += 1;
                Constants.speed += 0.8f;
                PlayerInfos.pi.levelTxt.text = "Level : " + currentLevel;
                if (currentLevel == 2)
                {
                    GameObject plane = GameObject.FindGameObjectWithTag("plane");
                    Color32 color = new Color32(101, 140, 105, 0);
                    plane.GetComponent<Renderer>().material.color = color;
                }
            }
        }
        if (Endgame1.activeSelf == true)
        {
            Endgame1.transform.Translate(0, 0, -3 * Time.deltaTime, Space.World);
        }
    }
    IEnumerator EndGame1()
    {
        yield return new WaitForSeconds(15);
        //GameObject[] cubesG = GameObject.FindGameObjectsWithTag("greenCube");
        //GameObject[] cubesO = GameObject.FindGameObjectsWithTag("orangeCube");
        //GameObject[] cubesR = GameObject.FindGameObjectsWithTag("redCube");
        //GameObject[] cubesB = GameObject.FindGameObjectsWithTag("blackCube");
        //foreach (var cube in cubesG)
        //{
        //    Destroy(cube);
        //}
        //foreach (var cube in cubesO)
        //{
        //    Destroy(cube);
        //}
        //foreach (var cube in cubesR)
        //{
        //    Destroy(cube);
        //}
        //foreach (var cube in cubesB)
        //{
        //    Destroy(cube);
        //}
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float pos = player.transform.position.z;
        Endgame1.SetActive(true);
        Endgame1.transform.Translate(0,0,pos+15f);
        print(Endgame1);



        
    }
}
