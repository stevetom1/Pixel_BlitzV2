using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    public int totalExperience;
    public int currentLevel;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
