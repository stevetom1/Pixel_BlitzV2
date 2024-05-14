using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLives : MonoBehaviour
{
    [SerializeField] public static int maxHp = 3;
    int hp;
    float bulletTimer;

    public GameObject[] hearts;

    public TextMeshProUGUI hpText;

    public GameObject deathScreen;
    public GameObject player;

    void Start()
    {
        hp = maxHp;
    }

    void Update()
    {
        hpText.text = "HP: " + hp + "/" + maxHp;
        //xpText.text = "XP: " + exp;
        //levelText.text = "Level: " + level;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            int damageAmount = 1;
            GameManager.instance.PlayerTakeDamage(damageAmount);
        }
    }


    public void TakeDamage(int damage)
    {
        hp -= damage;
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
        if (hp < 1)
        {
            Destroy(hearts[0].gameObject);
        }
        else if(hp < 2)
        {
            Destroy(hearts[1].gameObject);
        }
        else if(hp < 3)
        {
            Destroy(hearts[2].gameObject);
        }
    }










    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_1");
    }

    public void Menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
