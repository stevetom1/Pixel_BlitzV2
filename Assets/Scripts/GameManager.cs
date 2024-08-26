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
    public GameObject player;

    private Collider2D playerCollider;

    public GameObject pauseScreen;
    public GameObject deathScreen;
    public GameObject dashIcon;
    public GameObject teleportIcon;
    public GameObject scoreText;



    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        BeginTimer();
    }

    void Start()
    {
        playerCollider = player.GetComponent<Collider2D>();
        UpdateUI();
        DontDestroyOnLoad(pauseScreen);
    }

    void Update()
    {
    
    }

    public void PlayerTakeDamage(int damage)
    {
        playerLives.TakeDamage(damage);
        playerLives.UpdateHud();
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
        Time.timeScale = 0f;
        deathScreen.SetActive(true);
        player.SetActive(false);
        teleportIcon.SetActive(false);
        dashIcon.SetActive(false);
        scoreText.SetActive(false);
    }

    private void PauseMenu()
    {
        pauseScreen.SetActive(true);
        teleportIcon.SetActive(false);
        dashIcon.SetActive(false);
        scoreText.SetActive(false);
        Time.timeScale = 0f;     
    }
    public void Unpause()
    {
        pauseScreen.SetActive(false);
        teleportIcon.SetActive(true);
        dashIcon.SetActive(true);
        scoreText.SetActive(true);
        Time.timeScale = 1f;
    }

    public void BeginTimer()
    {
        //Timer timer = FindObjectOfType<Timer>();
        Timer.instance.BeginTimer();
    }

}
