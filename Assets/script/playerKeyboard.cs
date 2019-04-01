using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeyboard : MonoBehaviour
{

    public float speed = 8f;
    public float jumbForxe = 700f;
    public float maxVelocity = 4f;

    [SerializeField]
    private bool grounded = true;
    private Rigidbody2D myBody;
    private Animator anim;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void PlayerMoveKetBoard()
    {
        float forxeX = 0f;
        float forxeY = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal");
        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                if (grounded)
                {
                    forxeX = speed;
                }
                else
                {
                    forxeX = speed * 1.1f;
                }
                anim.SetBool("walk", true);
            }
            Vector3 temp = transform.localScale;
            temp.x = 1f;
            transform.localScale = temp;
        }
        else if(h < 0)
        {
          
            if (vel < maxVelocity)
            {
                if (grounded)
                {
                    forxeX = -speed;
                }
                else
                {
                    forxeX = -speed * 1.1f;
                }
                
                anim.SetBool("walk", true);
            }
            Vector3 temp = transform.localScale;
            temp.x = -1f;
            transform.localScale = temp;
        }
        else
        {
            anim.SetBool("walk", false);

        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (grounded)
            {
                grounded = false;
                forxeY = jumbForxe;
            }
        }

        myBody.AddForce(new Vector2(forxeX, forxeY));
    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Ground") {
            grounded = true;

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerMoveKetBoard();
    }
}
