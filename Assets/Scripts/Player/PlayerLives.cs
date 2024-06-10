using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] public static int maxHp = 3;
    private int hp;
    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private float invincibilityDuration = 2.0f;

    public GameObject[] hearts;
    public TextMeshProUGUI hpText;
    public GameObject deathScreen;
    public GameObject pauseScreen;
    public GameObject player;

    void Start()
    {
        hp = maxHp;
        UpdateHud();
    }

    void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseMenu();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.tag == "Enemy" || collision.tag == "enemyBullet") && !isInvincible)
        {
            int damageAmount = 1;
            TakeDamage(damageAmount);
        }
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
            return;

        hp -= damage;
        UpdateHud();

        if (IsDead())
        {
            deathScreen.SetActive(true);
            player.SetActive(false);
            Time.timeScale = 0f;
        }
        else
        {
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
        }
    }

    public bool IsDead()
    {
        return hp <= 0;
    }

    public int GetHP()
    {
        return hp;
    }

    public void UpdateHud()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < hp);
        }
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }
    public void Retry_2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_2");
    }
    public void Retr_3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_3");
    }
    public void Retry_Endless()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_Endless");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    private void PauseMenu()
    {
        pauseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Unpause()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1f;
    }
}
