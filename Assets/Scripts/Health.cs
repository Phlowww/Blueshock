using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float hp;

    private Slider healthBar;
    void Start()
    {
        healthBar = GetComponent<Slider>();
        healthBar.maxValue = hp;

    }

    
    void Update()
    {
        
    }

    public void TakeDamage(float damageTaken)
    {
        hp -= damageTaken;
        healthBar.value = hp;
    }
}
