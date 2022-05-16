using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
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
        if (playerHealth.hp <= 0)
        {
            Destroy(gameObject);
            deathScreen.SetActive(true);
        }

        PauseScreen();
        HandlePauseTime();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(10f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHealth.TakeDamage(0.5f);
        }
    }

    public void PauseScreen()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            pauseScreen.SetActive(isPaused);
        }
    }

    private void HandlePauseTime()
    {
        if (isPaused == true)
        {
            Time.timeScale = 0;
        }
        else if(isPaused == false)
        {
            Time.timeScale = 1;
        }
    }
}
