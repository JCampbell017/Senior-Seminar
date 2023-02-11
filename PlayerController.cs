using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float speed = 5.0f;
    
    // Bounds of player on map
    public Transform topLeft;
    public Transform bottomRight;
    private float xMin, xMax, yMin, yMax;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        xMin = topLeft.position.x;
        xMax = bottomRight.position.x;
        yMin = topLeft.position.y;
        yMax = bottomRight.position.y;
    }

    void Update(){
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f)*speed;
        animator.SetFloat("Horizontal", rb.velocity.x);
        animator.SetFloat("Vertical", rb.velocity.y);
        animator.SetFloat("Magnitude", rb.velocity.magnitude);
        this.transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax),Mathf.Clamp(transform.position.y, yMin, yMax), this.transform.position.z);

    }
}
