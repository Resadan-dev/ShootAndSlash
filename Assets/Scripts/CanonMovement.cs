using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CanonMovement : MonoBehaviour
{
    public CharacterController cc;
    public static CanonMovement canonM;
    public int score = 0;
    public TextMeshProUGUI scoreTxt;

    private void Awake()
    {
        canonM = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerInfos.pi.isGameOver == false)
        {
            if (CameraMovement.cm.GetCamPosition() < 3)
                cc.Move(new Vector3(0, 0, 2 * Time.deltaTime));
            if (CameraMovement.cm.GetCamPosition() > 3 && CameraMovement.cm.GetCamPosition() < 9) 
                cc.Move(new Vector3(0, 0, 3 * Time.deltaTime));
            if (CameraMovement.cm.GetCamPosition() > 9 && CameraMovement.cm.GetCamPosition() < 12) 
                cc.Move(new Vector3(0, 0, 4 * Time.deltaTime));
            if (CameraMovement.cm.GetCamPosition() > 12)
                cc.Move(new Vector3(0, 0, 6 * Time.deltaTime));
        }
    }
}
