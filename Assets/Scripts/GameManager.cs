using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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
        playerLives.UpdateHud();
        //UpdateUI();
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
       //playerLives.UpdateHud();
       // xpText.text = "XP: " + playerLives.exp;
       // levelText.text = "Level: " + playerLives.level;
    }

    void GameOver()
    {
        deathScreen.SetActive(true);
        player.SetActive(false);
        Time.timeScale = 0f;
    }
}
