using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class ExpirienceManager : MonoBehaviour
{
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] Image experienceFill;

    private DontDestroy dontDestroy;

    void Start()
    {
        UpdateLevel();
        //Debug.Log("started");
        dontDestroy = FindObjectOfType<DontDestroy>();
    }

    void Update()
    {
        //Debug.Log(totalExperience);
        /*if(Input.GetMouseButtonDown(0))
        {
            AddExperience(5);
        }*/
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        Debug.Log(totalExperience);
    }

    private void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateLevel();

            //here level up mechanics
        }
    }

    private void UpdateLevel()
    {
        previousLevelsExperience = (int)experienceCurve.Evaluate(currentLevel);
        nextLevelsExperience = (int)experienceCurve.Evaluate(currentLevel+ 1);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelsExperience;
        int end = nextLevelsExperience - previousLevelsExperience;

        levelText.text = currentLevel.ToString();
        experienceText.text = start + "exp / " + end + " exp";
        experienceFill.fillAmount = (float)start / (float)end;
    }
}
