using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class copterHover : MonoBehaviour {

    public GameObject self;
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
        if (flipper <= 40)
        {
            transform.position = new Vector3(otherPos.x, otherPos.y + .05f, otherPos.z);
        }
        else
        {
            transform.position = new Vector3(otherPos.x, otherPos.y - .05f, otherPos.z);
        }
        if (flipper >= 80)
            flipper = 0;

    }
}
