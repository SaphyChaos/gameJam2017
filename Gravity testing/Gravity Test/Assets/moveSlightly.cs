using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveSlightly : MonoBehaviour {
    public GameObject self;
    private int flipper;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        var otherPos = self.transform.position;
        flipper += 1;
        if (flipper < 30) {
            transform.position = new Vector3(otherPos.x + .001f, otherPos.y, otherPos.z);
        }
        else{
            transform.position = new Vector3(otherPos.x - .001f, otherPos.y, otherPos.z);
        }
        if (flipper >= 90)
            flipper = -30;
            
    }
}
