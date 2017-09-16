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
	public bool Spawned = false;


	public Vector2 originPosition;
	public Vector2 offset = new Vector2(5, 5);

	void Start(){
		//Vector2 randomPosition1 = originPosition + new Vector2 (Random.Range(0, 0), Random.Range (0, 0));
		//Instantiate(platform, randomPosition1, Quaternion.identity);
		originPosition = transform.position;
		GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0f, 100));
	}

    void Update () {
		//if (((GetComponent<Rigidbody2D>().position < (originPosition + offset)) || (GetComponent<Rigidbody2D>().position >= (originPosition)))&& Spawned == false) {
			//print ("0w0");
			//Spawn ();
		//}
    }

    public void Spawn()
    {
		Spawned = true;
		//horizontalMax = horizontalMax + GetComponent<Rigidbody2D>().gravityScale;
		//horizontalMin = horizontalMin * gravityScale;
		//verticalMax = verticalMax * gravityScale;
		/*
		Vector2 randomPosition1 = originPosition + new Vector2 (Random.Range(GetComponent<Rigidbody2D>().gravityScale, GetComponent<Rigidbody2D>().gravityScale), Random.Range (0, 0));
		Instantiate(platform, randomPosition1, Quaternion.identity);
		originPosition = randomPosition1;
		*/
		for (int i = 0; i < maxPlatforms; i++)
        {
			Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax)+ GetComponent<Rigidbody2D>().gravityScale, Random.Range (verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}