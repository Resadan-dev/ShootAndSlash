using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public static CameraMovement cm;
    public int score = 0;
    public TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        cm = this;
    }
    public float GetCamPosition()
    {
        return this.transform.localPosition.z;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (PlayerInfos.pi.isGameOver == false)
        //{
        //    if (transform.localPosition.z < 3)
        //        transform.Translate(0, 0, 2 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 3 && transform.localPosition.z < 9)
        //        transform.Translate(0, 0, 3 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 9 && transform.localPosition.z < 12)
        //        transform.Translate(0, 0, 4 * Time.deltaTime, Space.World);
        //    if (transform.localPosition.z > 12)
        //        transform.Translate(0, 0, 6 * Time.deltaTime, Space.World);

        //}
    }
}
