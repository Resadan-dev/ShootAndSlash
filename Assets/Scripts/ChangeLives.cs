using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLives : MonoBehaviour
{
    private string input;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReadStringInput(string s)
    {
        int input = Convert.ToInt32(s);
        Constants.nbLives = input;
    }
}
