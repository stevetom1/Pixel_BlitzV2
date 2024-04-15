using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb;
    private GameManager gameManager;

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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.ActivateDash(rb);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            gameManager.ActivateTeleport(rb, mousePosition);
        }
    }
}
