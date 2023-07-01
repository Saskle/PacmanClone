using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // don't allow player input if the game is over
        if (!GameManager.Instance.gameOver)
        {
            Move();
            // stop all animations?
        }
    }

    private void Move()
    {
        float horizontalMove = Input.GetAxis("Horizontal");
        float verticalMove = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalMove * speed, verticalMove * speed);

        // horizontal and vertical movement can be negative, Mathf.Abs makes them always positive
        anim.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalMove));
        anim.SetFloat("VerticalSpeed", Mathf.Abs(verticalMove));

        if (horizontalMove < 0 || verticalMove < 0)
        {
            // mirror the animation
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        else
        {
            // flip it back to normal (moving right is default)
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
    }
}
