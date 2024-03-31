using System.Collections;
using UnityEngine;
using static Cinemachine.DocumentationSortingAttribute;

public class PlayerAddXp : MonoBehaviour
{
    private GameManager gameManager;

    public int requiredExp;
    public int level;
    public int exp;

    void Start()
    {
        gameManager = GameManager.instance;
    }

    public void AddXP(int xpAmount)
    {
        exp += xpAmount;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            AddXP(10);
        }*/
    }

    private void CheckLevelUp()
    {
        if (exp >= requiredExp)
        {
            level++;
            requiredExp = requiredExp * 5 / 2;
            exp = 0;
        }
    }

    public void TriggerXP(int xpAmount)
    {
        AddXP(xpAmount);
    }

    public void Awake()
    {
            
    }
}
