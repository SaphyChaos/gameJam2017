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
    public bool hitHim;
    public bool hitHimBasic;
    //public Vector3 hitboxLocation;
    //public GameObject MyBird;
    //public Animation animation;
    //private IEnumerator coroutine;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hitHim = false;
        hitHimBasic = false;
        //print("wew");
    }
    private void Awake()
    {

    }
    // Update is called once per frame
    void Update () {
        //hitbox.enabled = false;
        if((attackGo == true) && (animator.GetCurrentAnimatorStateInfo(0).IsName("tenor")))
        {
            var hitboxLocation = transform.position;
            //m_camera.transform.position = new Vector3(1, 1, (m_camera.transform.position.z));
            m_camera.transform.position = new Vector3(hitboxLocation.x, hitboxLocation.y, (m_camera.transform.position.z));
        }
        if ((attackGo == true)&& (animator.GetCurrentAnimatorStateInfo(0).IsName("done")))
        {
            //print("fip");
            //hitbox.enabled = true;
            hitHim = true;
            Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
            tmp.a = 0f;
            this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;
            attackGo = false;
            if(!hitHimBasic)
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
        cameraOrigonalPosition = new Vector3(0f, 0f, 0f);
        //cameraOrigonalPosition = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z);
        m_cameraAnimation.Play("cameraAnimation(1)", -1, 0f);
        attackGo = true;
        animator.Play("tenor", -1, 0f);
        Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
        tmp.a = 1f;
        this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;

    }
    public void enableItBasic()
    {
        //this.spriteRenderer.sprite = sprite2;
        //this.spriteRenderer.enabled = true;
        //this.animator.enabled = true;
        //cameraOrigonalPosition = new Vector3(m_camera.transform.position.x, m_camera.transform.position.y, m_camera.transform.position.z);
        //m_cameraAnimation.Play("cameraAnimation(1)", -1, 0f);
        attackGo = true;
        animator.Play("guitarSmash", -1, 0f);
        hitHimBasic = true;
        //Color tmp = this.spriteRenderer.GetComponent<SpriteRenderer>().color;
        //tmp.a = 1f;
        //this.spriteRenderer.GetComponent<SpriteRenderer>().color = tmp;

    }
    void OnTriggerStay2D(Collider2D col)
    {
        //m_enemy = GameObject.Find("Bird");
        //print("ooh");
        if ((col.gameObject.tag == "Enemy") && (hitHimBasic == true) && (hitHim == true))
        {
            print("ahhh");
            m_enemy.GetComponent<Bird>().damage(50);
            hitHim = false;
            hitHimBasic = false;
        }
        else  if ((col.gameObject.tag == "Enemy") && (hitHim == true))
        {
            //print("ahhh");
            m_enemy.GetComponent<Bird>().damage(500);
            hitHim = false;
        }

    }
    public void fixCamera()
    {
        print("hm");
        float x = m_camera.transform.position.x;
        float y = m_camera.transform.position.y;
        if (m_camera.transform.position.x < cameraOrigonalPosition.x)
        {
            x += 1;
        }
        if (m_camera.transform.position.y < cameraOrigonalPosition.y)
        {
            y += 1;
        }
        if (m_camera.transform.position.x > cameraOrigonalPosition.x)
        {
            x -= 1;
        }
        if (m_camera.transform.position.y > cameraOrigonalPosition.y)
        {
            y -= 1;
        }
        if (m_camera.transform.position.y != cameraOrigonalPosition.y || m_camera.transform.position.x != cameraOrigonalPosition.x)
            fixCamera();
        //m_camera.transform.position = new Vector3(cameraOrigonalPosition.x, cameraOrigonalPosition.y, cameraOrigonalPosition.z);
        //print("df");
    }
}
