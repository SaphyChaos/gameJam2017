using UnityEngine;
using System.Collections;

public class onColision : MonoBehaviour
{
    public Animator animator;
    public Animator animatorL;
    //private Rigidbody2D rb2d;
    //public PlatformerCharacter2D myCharacter;
    void OnCollisionEnter2D (Collision2D col)
    {
        GameObject varGameObject = GameObject.FindWithTag("Player");
        //print ("collide!");
        if (col.gameObject.tag == "platform")
        {
			print ("helloo");
			GetComponent<spawnPlatformsVert> ().Spawn ();
			GetComponent<SpawnPlatforms> ().Spawn ();
			Destroy (col.gameObject);
        }
		else if (col.gameObject.tag == "Enemy") {
            //print("aaaah");
            //Destroy (col.gameObject);
            animator.Play("curtainAnim", -1, 0f);
            animatorL.Play("curtainAnimLeft", -1, 0f);
            //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            varGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; ;
            //Application.LoadLevel("Combat");
        }
    }
    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("done"))
            Application.LoadLevel("Combat");
    }
}