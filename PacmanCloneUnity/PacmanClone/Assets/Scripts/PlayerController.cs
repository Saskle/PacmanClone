using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 4f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();


    }

    private void Move()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);

        //rb.AddForce(Vector2.up * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //rb.AddForce(Vector2.right * Input.GetAxis("Vertical") * speed * Time.deltaTime);

        //transform.Translate(Vector3.right * Input.GetAxis("Horizontal") * speed * Time.deltaTime);
        //transform.Translate(Vector3.up * Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
