using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [Header("Ability1")]
    public Image abilityImage1;
    public float cooldown1 = 2;
    bool isCooldown = false;
    public KeyCode ability1;

    [Header("Ability2")]
    public Image abilityImage2;
    public float cooldown2 = 3;
    bool isCooldown2 = false;
    public KeyCode ability2;


    void Start()
    {
        abilityImage1.fillAmount = 0;
        abilityImage2.fillAmount = 0;

    }

    void Update()
    {
        Ability1();
        Ability2();
    }

    void Ability1()
    {
        abilityImage1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

        if (Input.GetKey(ability1)&& isCooldown == false)
        {
            isCooldown= true;
            abilityImage1.fillAmount = 1;
        }

        if(abilityImage1.fillAmount <= 0)
        {
            abilityImage1.fillAmount = 0;
            isCooldown = false;
        }
    }

    void Ability2()
    {
        abilityImage2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

        if (Input.GetKey(ability2) && isCooldown2 == false)
        {
            isCooldown2 = true;
            abilityImage2.fillAmount = 1;
        }

        if (abilityImage2.fillAmount <= 0)
        {
            abilityImage2.fillAmount = 0;
            isCooldown2 = false;
        }
    }
}
