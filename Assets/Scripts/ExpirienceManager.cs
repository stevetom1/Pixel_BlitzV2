using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Diagnostics.Tracing;

public class ExpirienceManager : MonoBehaviour
{
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelsExperience, nextLevelsExperience;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] GameObject levelUpText;
    [SerializeField] Image experienceFill;

    private Data data;

    void Start()
    {
        data = FindObjectOfType<Data>();
        totalExperience = data.totalExperience;
        currentLevel= data.currentLevel;
        UpdateLevel();
    }

    void Update()
    {
        UpdateInterface();
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        data.totalExperience = totalExperience;
    }

    private void CheckForLevelUp()
    {
        if(totalExperience >= nextLevelsExperience)
        {
            currentLevel++;
            UpdateLevel();
            data.currentLevel= currentLevel;
            StartCoroutine(LevelUpShowTime());
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
    IEnumerator LevelUpShowTime()
    {
        levelUpText.SetActive(true);
        yield return new WaitForSeconds(2);
        levelUpText.SetActive(false);
    }

}
