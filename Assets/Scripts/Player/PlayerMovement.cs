using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    public float speed;
    [SerializeField]
    public float shiftSpeed;
    Transform t;
    public Rigidbody2D rb;
    public Camera cam;
    Vector2 movement;
    Vector2 mousePos;
    [SerializeField]
    Vector2 borders;
    void Start()
    {
        t = GetComponent<Transform>();
    }
    //a

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = shiftSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 9;
        }

        if (t.position.x < borders.x)
        {
            t.position = new Vector3(borders.x, t.position.y, t.position.z);
        }

        if (t.position.x > borders.y)
        {
            t.position = new Vector3(borders.y, t.position.y, t.position.z);
        }

        if (transform.position.y > 9f)
        {
            transform.position = new Vector3(transform.position.x, 9f, 0);
        }
        else if (transform.position.y <= -9.25f)
        {
            transform.position = new Vector3(transform.position.x, -9.25f, 0);
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }


}
