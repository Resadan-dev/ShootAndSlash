using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        bulletSpawnCube.transform.rotation = Quaternion.Euler(0, randomization + 180, 0);

        if (rand.Next(0, Constants.probabilityBullet) == 0)
        {
            var bullet = Instantiate(cubeBulletPrefab, bulletSpawnCube.position, bulletSpawnCube.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnCube.forward * bulletSpeed;
            bullet.transform.tag = "cubeBullet";
            
            if (transform.tag == "greenCube")
            {
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("green");
            }
            if (transform.tag == "orangeCube")
            {
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("orange");
            }
            if (transform.tag == "redCube")
            {
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = Constants.GetCubeColor("red");
            }
        }
        bulletSpawnCube.transform.rotation = Quaternion.Euler(0, -randomization + 180, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
