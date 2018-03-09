using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oocPathFinding : MonoBehaviour {
    //private Gameobject lineOfSight;
    private bool iSeeYouFucker;
    private Vector3 pcPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (iSeeYouFucker)
        {
            pcPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
            if (pcPosition.x < this.transform.position.x)
            {
                this.transform.position.x = new vector3(this.transform.position.x + 1);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            iSeeYouFucker = true;
        }
    }
}
