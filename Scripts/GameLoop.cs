﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Quit") > 0)
        {
            Debug.Log("Application Quit?");
            Application.Quit();
        }	
	}
}
