using UnityEngine;
using System.Collections;
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
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.down, 1000, 1 << LayerMask.NameToLayer("enemy"));
                if(hit.collider == null)
                {
                    print("headshot!");
                    dogHP.headShot = true;
                }
                Application.LoadLevel("Combat");
            }
        }
    }
}