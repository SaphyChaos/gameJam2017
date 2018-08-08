using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
namespace UnityStandardAssets._2D
{
    public class onColision : MonoBehaviour
    {
        public Animator animator;
        public Animator animatorL;
        public bool wall = false;
        //private Rigidbody2D rb2d;
        //public PlatformerCharacter2D myCharacter;
        void OnCollisionStay2D(Collision2D col)
        {
            GameObject varGameObject = GameObject.FindWithTag("Player");
            if(col.gameObject.name == "head")
            {
                this.GetComponent<PlatformerCharacter2D>().m_Grounded = false;
            }
            if (col.gameObject.tag == "wall")
            {
                wall = true;
                //this.gameObject.GetComponent<Platformer2DUserControl>().m_Jump = false;
                //this.GetComponent<PlatformerCharacter2D>().Move(0, false, false, false);
                //print(this.gameObject.GetComponent<Rigidbody2D>().transform.InverseTransformDirection(this.gameObject.GetComponent<Rigidbody2D>().velocity));
                //if((Input.GetAxis("Horizontal")) > 0)
                this.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, -200f));
            }
            else
                wall = false;
        }
        void OnCollisionEnter2D(Collision2D col)
        {
            GameObject varGameObject = GameObject.FindWithTag("Player");
            //print ("collide!");
            if ((col.gameObject.tag == "platform") && (this.gameObject.GetComponent<SpawnPlatforms>().enabled == true || this.gameObject.GetComponent<spawnPlatformsVert>().enabled == true))
            {
                print("helloo");
                GetComponent<spawnPlatformsVert>().Spawn();
                GetComponent<SpawnPlatforms>().Spawn();
                Destroy(col.gameObject);
            }
            else if (col.gameObject.tag == "Enemy" && !animator.GetCurrentAnimatorStateInfo(0).IsName("curtainAnim"))
            {
                //print("aaaah");
                //Destroy (col.gameObject);
                //print(col.gameObject.name);
                animator.Play("curtainAnim", -1, 0f);
                animatorL.Play("curtainAnimLeft", -1, 0f);
                //rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
                this.GetComponent<PlatformerCharacter2D>().Move(0f, false, false, false);
                varGameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll; ;
                //Application.LoadLevel("Combat");
            }
            else if (col.gameObject.tag == "door")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        /*
        void ontriggerstay2d(collider2d col)
        {
            print(col.gameobject.tag);
            if (col.gameobject.tag == "head")
            {
                print("headshot!");
            }
        }
        */
        private void Update()
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("done"))
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down, 10000, 1 << LayerMask.NameToLayer("enemy"));
                //print(hit.collider);
                if (hit.collider == GameObject.Find("Head").GetComponent<BoxCollider2D>())
                {
                    print("headshot!");
                    this.GetComponent<PlatformerCharacter2D>().Move(0f, false, false, false);
                    dogHP.headShot = true;
                }
                if (hit.collider == GameObject.Find("Back").GetComponent<BoxCollider2D>())
                {
                    print("backstab!");
                    this.GetComponent<PlatformerCharacter2D>().Move(0f, false, false, false);
                    dogHP.backStab = true;
                }
                //if(SceneManager.GetActiveScene().name == "spriteLand");
                //    SceneManager.LoadScene("Combat_Dark");
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //Application.LoadLevel("Combat");
            }
        }
    }
}