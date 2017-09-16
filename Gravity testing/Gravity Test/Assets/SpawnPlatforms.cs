using UnityEngine;
using System.Collections;

public class SpawnPlatforms : MonoBehaviour {

    public int maxPlatforms = 20;
    public GameObject platform;
    public float horizontalMin = 2.5f;
    public float horizontalMax = 5f;
    public float verticalMin = -3f;
    public float verticalMax = 3;


    private Vector2 originPosition;


    void Start () {

        originPosition = transform.position;
        Spawn ();
    
    }

    void Spawn()
    {
        for (int i = 0; i < maxPlatforms; i++)
        {
            Vector2 randomPosition = originPosition + new Vector2 (Random.Range(horizontalMin, horizontalMax), Random.Range (verticalMin, verticalMax));
            Instantiate(platform, randomPosition, Quaternion.identity);
            originPosition = randomPosition;
        }
    }

}