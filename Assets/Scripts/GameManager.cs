using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float dashDistance = 5f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 2f;
    public float teleportCooldown = 1f;

    private bool canDash = true;
    private bool canTeleport = true;

    public PlayerAddXp playerAddXp;
    public PlayerLives playerLives;

    public TextMeshProUGUI hpText;
    public TextMeshProUGUI xpText;
    public TextMeshProUGUI levelText;
    public GameObject deathScreen;
    public GameObject player;

    private Collider2D playerCollider;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        UpdateUI();
    }

    void Update()
    {

    }

    public void PlayerTakeDamage(int damage)
    {
        playerLives.TakeDamage(damage);
        UpdateUI();
        if (playerLives.IsDead())
        {
            GameOver();
        }
    }

    public void PlayerGainXP(int xpAmount)
    {
        playerAddXp.AddXP(xpAmount);
        UpdateUI();
    }

    void UpdateUI()
    {
       // hpText.text = "HP: " + playerLives.GetHP() + "/" + playerLives.maxHp;
       // xpText.text = "XP: " + playerLives.exp;
       // levelText.text = "Level: " + playerLives.level;
    }

    void GameOver()
    {
        deathScreen.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ActivateDash(Rigidbody2D rb)
    {
        if (canDash)
        {
            StartCoroutine(Dash(rb));
        }
    }

    public void ActivateTeleport(Rigidbody2D rb, Vector3 targetPosition)
    {
        if (canTeleport)
        {
            TeleportToPosition(rb, targetPosition);
            StartCoroutine(TeleportCooldown());
        }
    }

    private IEnumerator Dash(Rigidbody2D rb)
    {
        canDash = false;
        playerCollider.enabled = false;

        Vector3 startPosition = player.transform.position;
        Vector3 endPosition = startPosition + player.transform.right * dashDistance;

        float elapsedTime = 0f;
        while (elapsedTime < dashDuration)
        {
            rb.MovePosition(Vector3.Lerp(startPosition, endPosition, elapsedTime / dashDuration));
            elapsedTime += Time.fixedDeltaTime;
            yield return null;
        }

        rb.MovePosition(endPosition);

        playerCollider.enabled = true;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("dash");
    }

    private void TeleportToPosition(Rigidbody2D rb, Vector3 targetPosition)
    {
        rb.MovePosition(targetPosition);
        Debug.Log("Teleported to: " + targetPosition);
    }

    private IEnumerator TeleportCooldown()
    {
        canTeleport = false;
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}