﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject dBox;
    public Text dText;

    public bool dialogueActive;

    public string[] dialogLines;
    public int currentLine;

    private PlayerMovement thePlayer;


	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (dialogueActive && Input.GetKeyUp(KeyCode.Space))
        {
            //dBox.SetActive(false);
            //dialogueActive = false;

            currentLine++;
        }

        if(currentLine >= dialogLines.Length)
        {
            dBox.SetActive(false);
            dialogueActive = false;

            currentLine = 0;
            thePlayer.canMove = true;
        }

        dText.text = dialogLines[currentLine];
	}

    public void ShowBox(string dialogue)
    {
        dialogueActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    public void ShowDialogue()
    {
        dialogueActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}