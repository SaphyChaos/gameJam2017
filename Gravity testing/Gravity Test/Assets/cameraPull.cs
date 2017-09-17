using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class cameraPull : MonoBehaviour {
	public GameObject myBoy;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var otherPos = transform.position;
		transform.position = new Vector3(otherPos.x,otherPos.y,(-13+myBoy.GetComponent<Rigidbody2D>().gravityScale));
	}
}
