using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public GameObject Shield;
    public CharacterController cc;
    private void Awake()
    {
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Shield)
        {
            print("OK");
        }
        else
        {
            if (other.gameObject.tag == "cubeBullet")
            {
                if (Constants.GetValueInMemory("DashActivated") == 1)
                {

                }
                else
                {
                    int lifePlayer = Constants.GetValueInMemory("life");
                    print("lllllllife : "+lifePlayer);
                    if (lifePlayer > 1)
                    {
                        Renderer renderer = Shield.GetComponent<Renderer>();
                        renderer.sharedMaterial.color = new Color32(255, 255, 255, 0);
                        MeshRenderer meshRenderer = Shield.GetComponent<MeshRenderer>();
                        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                        PlayerInfos.pi.GetLife(-1);
                        PlayerInfos.pi.lifeTxt.text = "Life : "+lifePlayer;
                        Canon.can.cc.detectCollisions = false;
                        Renderer myRenderer = GetComponent<Renderer>();
                        Color32 newColor = new Color32(37, 90, 255, 20);
                        myRenderer.material.color = newColor;
                        yield return new WaitForSeconds(1);
                        Canon.can.cc.detectCollisions = false;
                        Color32 newColor2 = new Color32(37, 90, 255, 255);
                        myRenderer.material.color = newColor2;
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
