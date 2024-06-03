using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;
    public float invincibilityDuration = 1f;
    private bool canDash = true;


    public float teleportCooldown = 1f;
    private bool canTeleport = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            StartCoroutine(Dash());
        }

        if (Input.GetKeyDown(KeyCode.LeftControl) && canTeleport)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            StartCoroutine(TeleportCooldown());
            TeleportToPosition(mousePosition);
        }
    }

    IEnumerator Dash()
    {
        canDash = false;

        GetComponent<Collider2D>().enabled = false;

        Vector3 startPosition = transform.position;
        Vector3 endPosition = startPosition + transform.right * dashDistance;

        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / dashDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;

        GetComponent<Collider2D>().enabled = true;

        yield return new WaitForSeconds(dashCooldown);

        canDash = true;
    }

    void TeleportToPosition(Vector3 targetPosition)
    {
        Vector3 direction = targetPosition - transform.position;
        direction.Normalize();
        transform.position = targetPosition;
        Debug.Log("Teleported to: " + targetPosition);
    }

    IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}