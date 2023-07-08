using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CubeAttack : MonoBehaviour
{

    public Transform bulletSpawnCube;
    public GameObject cubeBulletPrefab;
    public float bulletSpeed = Constants.bulletSpeed;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SendBullet", 1f, 1f);
    }
    void SendBullet()
    {
        System.Random rand = new System.Random();
        float randomization = rand.Next(-10, 10);
        if (rand.Next(0, Constants.probabilityBullet) == 0)
        {   
            if (transform.tag == "greenCube")
            {
                bulletSpawnCube.transform.rotation = Quaternion.Euler(0, 180, 0);
                var bullet = Instantiate(cubeBulletPrefab, bulletSpawnCube.position, bulletSpawnCube.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnCube.forward * (bulletSpeed);
                bullet.transform.tag = "cubeBullet";
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("green");
            }
            if (transform.tag == "orangeCube")
            {
                bulletSpawnCube.transform.rotation = Quaternion.Euler(0, 180, 0);
                var bullet = Instantiate(cubeBulletPrefab, bulletSpawnCube.position, bulletSpawnCube.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnCube.forward * (bulletSpeed * 1.4f);
                bullet.transform.tag = "cubeBullet";
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("orange");
            }
            if (transform.tag == "redCube")
            {
                float angle = (float)ComputeAngle();
                bulletSpawnCube.transform.rotation = Quaternion.Euler(0, angle, 0);
                var bullet = Instantiate(cubeBulletPrefab, bulletSpawnCube.position, bulletSpawnCube.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnCube.forward * (bulletSpeed / 1.4f);
                bullet.transform.tag = "cubeBullet";
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("red");
            }
        }
        //bulletSpawnCube.transform.rotation = Quaternion.Euler(0, angle + 180, 0);

    }
    private double ComputeAngle()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            float x1 = player.transform.position.x;
            float z1 = player.transform.position.z;
            float x2 = bulletSpawnCube.transform.position.x;
            float z2= bulletSpawnCube.transform.position.z;

            double angle = Math.Atan((x1 - x2) / (z1 - z2)) * (180 / Math.PI);
            //if (z1 < z2)
            //{
                angle += 180;
            //}
            return angle;
        }
        return 0;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
