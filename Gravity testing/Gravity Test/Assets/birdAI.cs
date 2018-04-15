using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdAI : MonoBehaviour {
    public bool passed;
    private int dumbTimer;
    public GameObject moveScript;
	// Use this for initialization
	void Start () {
        passed = false;
	}
    void OnEnable()
    {
        passed = false;
        dumbTimer = 0;
    }
    // Update is called once per frame
    void Update () {
        print(dumbTimer);
        dumbTimer += 1;
		if (dumbTimer > (60*60))
        {
            passed = true;
        }

	}
}
