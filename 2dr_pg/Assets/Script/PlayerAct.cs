using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAct : MonoBehaviour
{

    Rigidbody2D rigid;
    Animator anim;
    public float speed;
    public GameManager manager;
    float h;
    float v;
    bool isHorizonMove;
    Vector3 dirVec;
    GameObject scanObject;
    // Start is called before the first frame update
    void Awake()
    {
        rigid= GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = manager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = manager.isAction ? 0 :Input.GetAxisRaw("Vertical");

        bool hDown = manager.isAction ? false : Input.GetButtonDown("Horizontal");
        bool hUp = manager.isAction ? false : Input.GetButtonUp("Horizontal");
        bool vDown = manager.isAction ? false : Input.GetButtonDown("Vertical");
        bool vUp = manager.isAction ? false : Input.GetButtonUp("Vertical");

        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp)
            isHorizonMove = h != 0;
        else if (vUp)
            isHorizonMove = h !=0;

        //Animation
        if (anim.GetInteger("hAxisRaw") != h)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("hAxisRaw", (int)h);
        }
        else if (anim.GetInteger("vAxisRaw") != v)
        {
            anim.SetBool("isChange", true);
            anim.SetInteger("vAxisRaw", (int)v);
        }
        else
            anim.SetBool("isChange", false);

        //Direction
        if (vDown && v == 1)
            dirVec = Vector3.up;
        else if (vDown && v == -1)
            dirVec = Vector3.down;
        else if (hDown && h == 1)
            dirVec = Vector3.right;
        else if (hDown && h == -1)
            dirVec = Vector3.left;

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
            manager.Action(scanObject);

    }
    void FixedUpdate()
    {
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec*speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec*0.7f, new Color(0,1,0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f,LayerMask.GetMask("playobject"));

        if (rayHit.collider != null)
        {
            scanObject = rayHit.collider.gameObject;
        }
        else
            scanObject = null;
    }
}
