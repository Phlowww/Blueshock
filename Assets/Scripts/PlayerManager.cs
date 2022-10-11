using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode;
using UnityEngine.Networking;
using Cinemachine;


public class PlayerManager : NetworkBehaviour
{
    private bool isPaused = false;
    public GameObject pauseScreen;
    public GameObject deathScreen;
    private Health playerHealth;
    


    
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponentInChildren<Health>();
    }

    

    

    // Update is called once per frame
    void Update()
    {
        if (IsLocalPlayer)
        {
            if (playerHealth.hp <= 0)
            {
                Destroy(gameObject);
                deathScreen.SetActive(true);
            }
        }


        PauseScreen();
        HandlePauseTime();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsLocalPlayer)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                playerHealth.TakeDamage(10f);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsLocalPlayer)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                playerHealth.TakeDamage(0.5f);
            }
        }

    }

    public void PauseScreen()
    {
        if (IsLocalPlayer)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                pauseScreen.SetActive(isPaused);
            }
        }

    }

    private void HandlePauseTime()
    {
        if (IsLocalPlayer)
        {
            if (isPaused == true)
            {
                Time.timeScale = 1;
            }
            else if (isPaused == false)
            {
                Time.timeScale = 1;
            }
        }

    }
}
