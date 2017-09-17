using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcamera : MonoBehaviour {

	public GameObject myCamera;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		var otherPos = myCamera.transform.position;
		var otherPoss = transform.position;
		transform.position = new Vector3(otherPos.x,otherPos.y,otherPoss.z);
	}
}