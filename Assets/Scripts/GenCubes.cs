using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class GenCubes : MonoBehaviour
{
    public GameObject block;
    public GameObject maxiCube;
    public Transform Cubes;
    public int levelSize;
    public float x5 = 1.5f - 1.537f;
    public float x4 = -0.1f + 1.537f;
    public float x3 = -1.7f + 1.537f;
    public float x2 = -3.3f + 1.537f;
    public float x1 = -4.9f + 1.537f;
    public float z = Constants.distance_Z_betweenCubes;
    public float y = 0.42f;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        //InvokeRepeating("CreateCubes", 0.0f, 10f);
        InvokeRepeating("CreateCubes", 0.0f, 0.70f);
        
        yield return new WaitForSeconds(13);
        CancelInvoke("CreateCubes");
        yield return new WaitForSeconds(12);
        z = Constants.distance_Z_betweenCubes + 1;
        InvokeRepeating("CreateCubes", 0.0f, 0.50f);


    }
    void CreateCubes()
    {
        System.Random rand = new System.Random();
        float posVariation = rand.Next(-6,6);
        if (rand.Next(0,3) == 0)
        {
            Instantiate(maxiCube, new Vector3(x1+3.2f, y, z), Quaternion.identity, Cubes);
        }
        else
        {
            for (int i = 0; i < levelSize; i++)
            {
                if (rand.Next(0, Constants.probabilityCubeCreation) == 0)
                {
                    Instantiate(block, new Vector3(x1 + posVariation/10, y, z + posVariation/10), Quaternion.identity, Cubes);
                }
                if (rand.Next(0, Constants.probabilityCubeCreation) == 0)
                {
                    Instantiate(block, new Vector3(x2 + posVariation / 10, y, z + posVariation / 10), Quaternion.identity, Cubes);
                }
                if (rand.Next(0, Constants.probabilityCubeCreation) == 0)
                {
                    Instantiate(block, new Vector3(x3 + posVariation / 10, y, z + posVariation / 10), Quaternion.identity, Cubes);
                }
                if (rand.Next(0, Constants.probabilityCubeCreation) == 0)
                {
                    Instantiate(block, new Vector3(x4 + posVariation / 10, y, z + posVariation / 10), Quaternion.identity, Cubes);
                }
                if (rand.Next(0, Constants.probabilityCubeCreation) == 0)
                {
                    Instantiate(block, new Vector3(x5 + posVariation / 10, y, z + posVariation / 10), Quaternion.identity, Cubes);
                }
                z = z + 1;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerInfos.pi.levelTxt.text == "Level : 1")
        {
            Cubes.transform.Translate(0, 0, -3 * Time.deltaTime, Space.World);
        }
        if (PlayerInfos.pi.levelTxt.text == "Level : 2")
        {
            Cubes.transform.Translate(0, 0, -5f * Time.deltaTime, Space.World);
        }

        //    if (transform.localPosition.z < 3)
        //        transform.Translate(0, 0, 2 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 3 && transform.localPosition.z < 9)
        //        transform.Translate(0, 0, 3 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 9 && transform.localPosition.z < 12)
        //        transform.Translate(0, 0, 4 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 12)
        //        transform.Translate(0, 0, 6 * Time.deltaTime, Space.World);
    }
}
