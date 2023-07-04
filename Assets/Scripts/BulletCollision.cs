using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject Shield;
    private void Awake()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Shield)
        {
            print("OK");
        }
        else
        {
            if (other.gameObject.tag == "Player")
            {
                if (PlayerPrefs.GetInt("DashActivated") == 1)
                {
                    print("C'est moi");
                    print("Tout va bien");
                }
                else
                {
                    print("C'est pas moi");
                    int lifePlayer = PlayerPrefs.GetInt("life");
                    print(lifePlayer);
                    if (lifePlayer == 2)
                    {
                        Renderer renderer = Shield.GetComponent<Renderer>();
                        renderer.sharedMaterial.color = new Color32(255, 255, 255, 0);
                        MeshRenderer meshRenderer = Shield.GetComponent<MeshRenderer>();
                        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                        PlayerInfos.pi.GetLife(-1);
                        PlayerInfos.pi.lifeTxt.text = "Life : 1";


                    }
                    else
                    {
                        Destroy(other.gameObject);
                        PlayerInfos.pi.GameOver();
                    }
                }
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
