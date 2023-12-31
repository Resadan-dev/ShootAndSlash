using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Canon : MonoBehaviour
{
    public static Canon can;
    public CharacterController cc;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public Rigidbody rb;
    public float canonSpeed = 95400f;
    private Vector3 moveDir;
    private Vector3 moveDash;
    private bool m_isAxisInUse = false;
    private bool m_isDashActivated = false;
    public bool isDashActivated = false;
    public GameObject Shield;
    public bool isCollisionBottomLimit = false;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        if (Constants.GetValueInMemory("armorBool") == 1)
        {
            Renderer renderer = Shield.GetComponent<Renderer>();
            renderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
            renderer.sharedMaterial.color = new Color32(157, 197, 227, 155);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "bottomLimit")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            isCollisionBottomLimit = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "bottomLimit")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            isCollisionBottomLimit = false;
        }
    }
    private IEnumerator OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "greenCube" || other.gameObject.tag == "orangeCube" || other.gameObject.tag == "redCube" || other.gameObject.tag == "blackCube" || other.gameObject.tag == "otherCube")
        {
            if (Constants.GetValueInMemory("DashActivated") == 1)
            {

            }
            else
            {
                int currentLife = Constants.GetValueInMemory("life");
                if (currentLife == 1)
                {
                    Destroy(gameObject);
                    PlayerInfos.pi.GameOver();
                }
                else
                {
                    Renderer renderer = Shield.GetComponent<Renderer>();
                    renderer.sharedMaterial.color = new Color32(255, 255, 255, 0);
                    
                    MeshRenderer meshRenderer = Shield.GetComponent<MeshRenderer>();
                    meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                    PlayerInfos.pi.GetLife(-1);
                    cc.detectCollisions = false;
                    Renderer myRenderer = GetComponent<Renderer>();
                    Color32 newColor = new Color32(37, 90, 255, 20);
                    myRenderer.material.color = newColor;
                    yield return new WaitForSeconds(1);
                    Color32 newColor2 = new Color32(37, 90, 255, 255);
                    myRenderer.material.color = newColor2;
                    cc.detectCollisions = true;
                }
            }
        }
        if (other.gameObject.tag == "cubeBullet")
        {
            if (Constants.GetValueInMemory("DashActivated") == 1)
            {

            }
            else
            {
                int currentLife = Constants.GetValueInMemory("life");
                print("current life : " + currentLife);
                if (currentLife == 1)
                {
                    Destroy(gameObject);
                    PlayerInfos.pi.GameOver();
                }
                else
                {
                    int lifePlayer = Constants.GetValueInMemory("life");
                    if (lifePlayer > 1)
                    {
                        Renderer renderer = Shield.GetComponent<Renderer>();
                        renderer.sharedMaterial.color = new Color32(255, 255, 255, 0);
                        MeshRenderer meshRenderer = Shield.GetComponent<MeshRenderer>();
                        meshRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                        PlayerInfos.pi.GetLife(-1);
                        
                        lifePlayer = Constants.GetValueInMemory("life");
                        PlayerInfos.pi.lifeTxt.text = "Life : " + lifePlayer;
                        cc.detectCollisions = false;
                        Renderer myRenderer = GetComponent<Renderer>();
                        Color32 newColor = new Color32(37, 90, 255, 20);
                        myRenderer.material.color = newColor;
                        yield return new WaitForSeconds(1);
                        Color32 newColor2 = new Color32(37, 90, 255, 255);
                        myRenderer.material.color = newColor2;
                        cc.detectCollisions = true;
                    }
                    else
                    {
                        Destroy(gameObject);
                        PlayerInfos.pi.GameOver();
                    }
                }

            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire1") != 0 && Constants.GetValueInMemory("newWeaponBool") == 0) 
        {
            if (m_isAxisInUse == false)
            {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                m_isAxisInUse = true;
            }
        }
        if (Input.GetAxisRaw("Fire1") == 0)
        {
            m_isAxisInUse = false;
        }
        if (Input.GetAxisRaw("Fire1") != 0 && Constants.GetValueInMemory("newWeaponBool") == 1)
        {
            if (m_isAxisInUse == false)
            {
            Vector3 position = bulletSpawnPoint.position;
            position.x = position.x + Constants.spawnBulletPositionRight;
            Vector3 position2 = bulletSpawnPoint.position;
            position2.x = position2.x - Constants.spawnBulletPositionRight;
            m_isAxisInUse = true;
            var bullet1 = Instantiate(bulletPrefab, position, bulletSpawnPoint.rotation);
            var bullet2 = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            var bullet3 = Instantiate(bulletPrefab, position2, bulletSpawnPoint.rotation);

            bullet1.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            bullet2.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            bullet3.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                
            }
        }

        moveDir = new Vector3(Input.GetAxis("Horizontal") * Constants.canonSpeedMovement, moveDir.y, Input.GetAxis("Vertical") * Constants.canonSpeedMovement);
        if (isCollisionBottomLimit)
        {
            if (Input.GetAxis("Vertical") >= 0)
            {
                cc.Move(moveDir * Time.deltaTime);
            }
            else
            {
                moveDir = new Vector3(Input.GetAxis("Horizontal") * Constants.canonSpeedMovement, moveDir.y, 0);
                cc.Move(moveDir * Time.deltaTime);
            }
        }
        else cc.Move(moveDir * Time.deltaTime);
        
        if (Input.GetAxisRaw("Fire3") == 0)
        {
            m_isDashActivated = false;
        }

        if ((Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0) && Input.GetAxisRaw("Fire3") != 0 && Constants.GetValueInMemory("DashActivated") != 2)
        {
            Constants.SetValueInMemory("DashActivated", 1);
            isDashActivated = true;
            
            if (m_isDashActivated == false)
            {
                moveDash = new Vector3(Input.GetAxis("Horizontal") * 200, moveDir.y, Input.GetAxis("Vertical") * 200);
                cc.Move(moveDash * Time.deltaTime);
                m_isDashActivated = true;
            }
            StartCoroutine(Wait());
        }
        if (Input.GetAxisRaw("Fire2") != 0 || Input.GetKey(KeyCode.E))
        {
            PlayerInfos.pi.GameOver();
        }
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.left * Time.deltaTime * 6);
        //}
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.right * Time.deltaTime * 6);
        //}
    }
    IEnumerator Wait()
    {
        Renderer myRenderer = GetComponent<Renderer>();
        Color32 newColor = new Color32(37, 90, 255, 20);
        myRenderer.material.color = newColor;
        PlayerInfos.pi.UpdateCoolDown(4);
        yield return new WaitForSeconds(0.5f);
        Constants.SetValueInMemory("DashActivated", 2);
        newColor = new Color32(37, 90, 255, 255);
        myRenderer.material.color = newColor;
        yield return new WaitForSeconds(0.5f);
        PlayerInfos.pi.UpdateCoolDown(3);
        yield return new WaitForSeconds(1);
        PlayerInfos.pi.UpdateCoolDown(2);
        yield return new WaitForSeconds(1);
        PlayerInfos.pi.UpdateCoolDown(1);
        yield return new WaitForSeconds(1);
        PlayerInfos.pi.UpdateCoolDown(0);
        Constants.SetValueInMemory("DashActivated", 0);


    }
}
