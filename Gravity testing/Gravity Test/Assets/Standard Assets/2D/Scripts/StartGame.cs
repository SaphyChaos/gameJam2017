using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Submit"))
			//change scene to main game
			Application.LoadLevel (1);	//set index of desired RPG Field in build
	}
}
