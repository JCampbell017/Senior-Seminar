using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGun : MonoBehaviour
{
    [SerializeField] private float speed = 3f;

    private Rigidbody2D body;
    private Vector2 axisMovement;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");
    }

    private void CheckFlip()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft)
        {
            transform.localScale = new Vector3(-0.009901837f, transform.localScale.y);
        }

        if (movingRight)
        {
            transform.localScale = new Vector3(0.009901837f, transform.localScale.y);
        }
    }
}
