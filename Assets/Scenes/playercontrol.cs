using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    public float Speed = 5f;
    public float Retriggerabledelay = 1f;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 moveDir;
    bool t = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {      
            if (Input.GetKey(KeyCode.Mouse0)&&t==true)
              { 
                anim.SetBool("jumping", true);
                t = false;
                Invoke("Retriggerable", Retriggerabledelay);
                }
        else
        {
            anim.SetBool("jumping", false);
            float moveX = 0f;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                moveX = +1f;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                moveX = -1f;
            }
            moveDir = new Vector3(moveX, rb.linearVelocity.y).normalized;

            if (moveX == 0)
                {
                    anim.SetBool("isRuning", false);
                }
            else
                {
                    anim.SetBool("isRuning", true);
                }
            if (moveX < 0)
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
            else if (moveX > 0)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
        }
        }
    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * Speed;
    }
    void Retriggerable()
    {

        if (Input.GetKey(KeyCode.Mouse0)){Invoke("Retriggerable", (Retriggerabledelay/5));}
        else {t = true; }
    }
}
