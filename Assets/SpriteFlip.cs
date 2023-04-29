using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlip : MonoBehaviour
{
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
        CheckFlip();
    }

    private void CheckFlip()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if (movingLeft)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f);
        }

        if (movingRight)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
