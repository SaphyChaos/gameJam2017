using UnityEngine;
using System.Collections;

public class onColision : MonoBehaviour
{
    void OnCollisionEnter2D (Collision2D col)
    {
		//print ("collide!");
        if(col.gameObject.tag == "platform")
        {
			print ("helloo");
			GetComponent<spawnPlatformsVert> ().Spawn ();
			GetComponent<SpawnPlatforms> ().Spawn ();
			Destroy (col.gameObject);
        }
    }
}