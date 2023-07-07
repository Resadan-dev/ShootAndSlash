using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Scripts;

public class GenCubes : MonoBehaviour
{
    public GameObject block;
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
    void Start()
    {

        //InvokeRepeating("CreateCubes", 0.0f, 10f);
        InvokeRepeating("CreateCubes", 0.0f, 0.35f);

    }
    void CreateCubes()
    {
        System.Random rand = new System.Random();
        float posVariation = rand.Next(-6,6);
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
            z = z + 2;
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
