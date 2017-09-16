using UnityEngine;
using System.Collections;
using UnityStandardAssets.Utility;

public class SpawnPlatforms : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = .5f;
    public float horizontalMax = 1f;
    public float verticalMin = 0f;
    public float verticalMax = 0f;


    private Vector2 originPosition;


    void Start () {

        originPosition = transform.position;
        Spawn ();
    
    }

    void Spawn()
    {
		//horizontalMax = horizontalMax + GetComponent<Rigidbody2D>().gravityScale;
		//horizontalMin = horizontalMin * gravityScale;
		//verticalMax = verticalMax * gravityScale;
		Vector2 randomPosition1 = originPosition + new Vector2 (Random.Range(GetComponent<Rigidbody2D>().gravityScale, GetComponent<Rigidbody2D>().gravityScale), Random.Range (verticalMin, verticalMax));
		Instantiate(platform, randomPosition1, Quaternion.identity);
		originPosition = randomPosition1;
        for (int i = 0; i < maxPlatforms; i++)
        {
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin * GetComponent<Rigidbody2D>().gravityScale, horizontalMax * GetComponent<Rigidbody2D>().gravityScale), Random.Range (verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}