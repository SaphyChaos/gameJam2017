using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckoff : MonoBehaviour {
    private Rigidbody m_Rigidbody;
    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(new Vector3(0f, 200, -400));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
