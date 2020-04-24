using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight;
    private Rigidbody2D rb;

    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool hittingWall;
    public Transform edgeCheck;
    private Vector3 initialLocalScale;

    private bool notAtEdge;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        initialLocalScale= transform.localScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        hittingWall = Physics2D.OverlapCircle(wallCheck.position,wallCheckRadius,whatIsWall);
        //if the circle overlaps whatIsWall "true" will be returned 
        notAtEdge= Physics2D.OverlapCircle(edgeCheck.position,wallCheckRadius,whatIsWall);
        
        if (hittingWall || !notAtEdge)
             moveRight= !moveRight;

        if (moveRight){
            transform.localScale=new Vector3 (-initialLocalScale.x,initialLocalScale.y,initialLocalScale.z);
            rb.velocity= new Vector2(moveSpeed,rb.velocity.y);
        }
        else {
           transform.localScale=new Vector3 (initialLocalScale.x,initialLocalScale.y,initialLocalScale.z);
           rb.velocity= new Vector2(-moveSpeed,rb.velocity.y); 
        }
    }
}