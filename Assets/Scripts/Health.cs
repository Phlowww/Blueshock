using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;

public class Health : NetworkBehaviour
{
    public float hp;

    //public NetworkVariable<float> hp = new NetworkVariable<float>();

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
