using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heliScript : MonoBehaviour {

    public GameObject self;
    public GameObject protag;
    private int flipper;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var otherPos = self.transform.position;
        flipper += 1;
        if (otherPos.x < -24.4)
        {
            protag.transform.position = otherPos;
            protag.GetComponent<Rigidbody2D>().gravityScale = 0;
            transform.position = new Vector3(otherPos.x + .2f, otherPos.y, otherPos.z);
        }
        //else
            //protag.GetComponent<Rigidbody2D>().gravityScale = 1;
    }
    //-24.4
}
