using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SickRiff : MonoBehaviour {
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Sprite sprite;
    public BoxCollider2D hitbox;
    public GameObject m_enemy;
    public Camera m_camera;
    public Animator m_cameraAnimation;
    private bool attackGo;
    public Vector3 cameraOrigonalPosition;
    //public Vector3 hitboxLocation;
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
        if((attackGo == true) && (this.spriteRenderer.sprite != sprite))
        {
            var hitboxLocation = transform.position;
            //m_camera.transform.position = new Vector3(1, 1, (m_camera.transform.position.z));
            m_camera.transform.position = new Vector3(hitboxLocation.x, hitboxLocation.y, (m_camera.transform.position.z));
        }
        if ((attackGo == true)&&(this.spriteRenderer.sprite == sprite))
        {
            hitbox.enabled = true;
            Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;
            attackGo = false;
            m_cameraAnimation.Play("cameraAnimation(-1)", -1, 0f);
            //m_cameraAnimation.Play("default", -1, 0f);
            //fixCamera();
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
        cameraOrigonalPosition = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z);
        m_cameraAnimation.Play("cameraAnimation(1)", -1, 0f);
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
    public void fixCamera()
    {
        m_camera.transform.position = new Vector3(cameraOrigonalPosition.x, cameraOrigonalPosition.y, cameraOrigonalPosition.z);
    }
}
