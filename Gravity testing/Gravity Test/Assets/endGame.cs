using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour {
    private int counter;
	// Use this for initialization
	void Start () {
        dogHP.Reset();
	}
	
	// Update is called once per frame
	void Update () {
        counter += 1;
        if (counter > 120)
            SceneManager.LoadScene(0);
	}
}
