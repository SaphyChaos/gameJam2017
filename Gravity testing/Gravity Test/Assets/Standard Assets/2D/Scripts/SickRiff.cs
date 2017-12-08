using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickRiff : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite sprite;
    public BoxCollider2D hitbox;
    public GameObject m_enemy;
    private bool attackGo;
    //public GameObject MyBird;
    //public Animation animation;
    //private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        //print("wew");
    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update () {
        hitbox.enabled = false;
        if ((attackGo == true)&&(this.spriteRenderer.sprite == sprite))
        {
            hitbox.enabled = true;
            Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;
            //this.spriteRenderer.enabled = false;
            //this.animator.enabled = false;
            //this.spriteRenderer.enabled = false;
            //this.spriteRenderer.sprite = sprite2;

        }
    }
    public void enableIt()
    {
        //this.spriteRenderer.sprite = sprite2;
        //this.spriteRenderer.enabled = true;
        //this.animator.enabled = true;
        attackGo = true;
        animator.Play("tenor", -1, 0f);
        Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        //m_enemy = GameObject.Find("Bird");
        if (col.gameObject.tag == "Enemy")
        {
            //print("ahhh");
            m_enemy.GetComponent<Bird>().damage(50);
        }
    }
}
