using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class EnemyCount : MonoBehaviour
{
    TextMeshProUGUI text; 
    public static int enemies;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>(); 
        if (text == null)
        {
            Debug.LogError("TextMeshProUGUI component not found on this GameObject.");
        }
    }
    void Update()
    {
        if (text != null)
        {
            text.text = enemies.ToString();
        }
    }

    public static void delEnem()
    {
        EnemyCount.enemies = 0;
    }
}
