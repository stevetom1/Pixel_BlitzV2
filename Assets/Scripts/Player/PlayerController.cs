using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gameManager;

    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;
    public float teleportCooldown = 1f;

    private bool canDash = true;
    private bool canTeleport = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameManager.instance;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb.velocity = movement;

        if (canDash && Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.ActivateDash();
        }

        if (canTeleport && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameManager.ActivateTeleport(mousePosition);
        }
    }
}
