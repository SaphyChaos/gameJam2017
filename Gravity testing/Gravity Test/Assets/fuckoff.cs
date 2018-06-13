using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fuckoff : MonoBehaviour {
    private Rigidbody m_Rigidbody;
    private Vector3 myVector;
    private int i;
    // Use this for initialization
    void Start () {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.AddForce(new Vector3(0f, 400, -400));
    }
	
	// Update is called once per frame
	void Update () {
        i -= 10;
        myVector = new Vector3(0, 0, i);
        Quaternion deltaRotation = Quaternion.Euler(myVector * Time.deltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
    }
}
