using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterChanger : MonoBehaviour
{

    public Sprite stageOneBlaster;
    public Sprite stageTwoBlaster;
    public Sprite stageThreeBlaster;
    public Sprite stageFourBlaster;
    public Sprite stageFiveBlaster;
    private SpriteRenderer spriteRenderer;
    public PlayerAimWeapon fireController;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeBlaster();
    }

    public void ChangeBlaster()
    {
        if (ScoreManager.instance.score >= 150)
        {
            spriteRenderer.sprite = stageTwoBlaster;
            fireController.fireRate = 15f;
        }

        if (ScoreManager.instance.score >= 500)
        {
          spriteRenderer.sprite = stageThreeBlaster;
          fireController.fireRate = 0.3f;
        }
        if (ScoreManager.instance.score >= 1500)
        {
          spriteRenderer.sprite = stageFourBlaster;
          fireController.fireRate = 0.002f;
        }
        if (ScoreManager.instance.score >= 3000)
        {
          spriteRenderer.sprite = stageFiveBlaster;
          fireController.fireRate = 0.05f;
        }
    }
}
