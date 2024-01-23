using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ensures that these components are attached to the gameobject
[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public bool TestMode = false;

    //Components
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator anim;

    //Movemement Var
    [SerializeField] private float speed = 7.0f;
    [SerializeField] private float jumpforce = 300.0f;

    //Groundcheck stuff
    [SerializeField] private bool isGrounded;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask isGroundLayer;
    [SerializeField] private float groundCheckRadius = 0.02f;

    // Start is called before the first frame update
    void Start()
    {
        //Component references grabbed through script
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>(); 
        anim = GetComponent<Animator>();

        if (speed <= 0)
        {
            speed = 7.0f;
            if (TestMode) Debug.Log("Speed has been set to a default value of 7.0f " + gameObject.name);
        }

        if (groundCheckRadius <= 0)
        {
            groundCheckRadius = 0.02f;
            if (TestMode) Debug.Log("Hey our ground check radius was defauted to 0.2f " + gameObject.name);
        }

        if (GroundCheck == null)
        {
            GameObject obj = new GameObject();
            obj.transform.SetParent(gameObject.transform);
            obj.transform.localPosition = Vector3.zero;
            obj.name = "GroundCheck";
            GroundCheck = obj.transform;
            if (TestMode) Debug.Log("GroundCheck Object is Created " + gameObject.name);
        }

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, groundCheckRadius, isGroundLayer);

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }

        anim.SetBool("IsGrounded", isGrounded);
        anim.SetFloat("Speed", Mathf.Abs(xInput));

        //Sprite Flipping
        if (xInput != 0) sr.flipX = (xInput < 0);
       
    }
}
