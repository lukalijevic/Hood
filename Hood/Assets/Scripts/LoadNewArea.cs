﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadNewArea : MonoBehaviour {

    public string levelToLoad;

    public string exitpoint;

    private PlayerMovement thePlayer;

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            Application.LoadLevel(levelToLoad);
            thePlayer.startPoint = exitpoint;
        }
    }
}
