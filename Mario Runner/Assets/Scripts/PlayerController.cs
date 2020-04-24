using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float MoveVelocity;
    public float MoveSpeed= 5;
    public float JumpHeight= 5;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private bool doubleJumped;
    private Animator anim;
    private Rigidbody2D rb;
    private Vector3 initialLocalScale;
    public Transform firePoint;//the point we are shooting from
    public GameObject fireBall;//the object we are gonna shoot
    public float knockBack;//knockback intensity in velocity
    public float knockBackLength;//seconds
    public float knockBackCount;
    public bool knockFromRight;

    void Start()
    {
      anim = GetComponent<Animator>();  
      rb = GetComponent<Rigidbody2D>();
      initialLocalScale= transform.localScale;
      
    }

   void FixedUpdate() {
      grounded = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
      //if the circle overlaps whatIsGround "true" will be returned 
    }

    // Update is called once per frame
    void Update()
    {
       if (grounded)
       doubleJumped = false;
       anim.SetBool ("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
           //GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
           jump();
        }
   
        if (Input.GetKeyDown(KeyCode.Space) && !doubleJumped && !grounded)
        {
           //GetComponent<Rigidbody2D>().velocity = new Vector2 (GetComponent<Rigidbody2D>().velocity.x,JumpHeight);
           jump();
           doubleJumped = true;
        }

      MoveVelocity= 0f; 
        if (Input.GetKey(KeyCode.RightArrow))
        {
           //rb.velocity = new Vector2 (MoveSpeed,rb.velocity.y);
           MoveVelocity= MoveSpeed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
           //rb.velocity = new Vector2 (-MoveSpeed,rb.velocity.y);
            MoveVelocity= -MoveSpeed;
        }
        if (knockBackCount <= 0){
            rb.velocity= new Vector2(MoveVelocity,rb.velocity.y);
        }
        else {
           if(knockFromRight)
           rb.velocity= new Vector2(-knockBack,knockBack);
           if(!knockFromRight)
           rb.velocity= new Vector2(knockBack,knockBack);
           knockBackCount-=Time.deltaTime;
        }

        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

       if (rb.velocity.x > 0) 
            transform.localScale = new Vector3(initialLocalScale.x, initialLocalScale.y, initialLocalScale.z);
        else if (rb.velocity.x < 0) 
            transform.localScale = new Vector3(-initialLocalScale.x, initialLocalScale.y, initialLocalScale.z);

            if(Input.GetKeyDown(KeyCode.LeftAlt))
            {
               Instantiate(fireBall,firePoint.position,firePoint.rotation);
            }
    }

    public void jump()
    {
       rb.velocity = new Vector2 (rb.velocity.x,JumpHeight);
    }
}
