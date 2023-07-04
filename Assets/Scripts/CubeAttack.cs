using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAttack : MonoBehaviour
{

    public Transform bulletSpawnCube;
    public GameObject cubeBulletPrefab;
    public float bulletSpeed = -2f;
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

        if (rand.Next(0, 4) == 0)
        {
            var bullet = Instantiate(cubeBulletPrefab, bulletSpawnCube.position, bulletSpawnCube.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnCube.forward * bulletSpeed;
            bullet.transform.tag = "cubeBullet";
            
            if (transform.tag == "greenCube")
            {
                Color32 newColor = new Color32(0, 255, 0, 0);
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = newColor;
            }
            if (transform.tag == "orangeCube")
            {
                Color32 newColor = new Color32(255, 155, 0, 0);
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = newColor;
            }
            if (transform.tag == "redCube")
            {
                Color32 newColor = new Color32(255, 0, 0, 0);
                var renderer = bullet.GetComponent<Renderer>();
                renderer.material.color = newColor;
            }
        }
        bulletSpawnCube.transform.rotation = Quaternion.Euler(0, -randomization + 180, 0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
