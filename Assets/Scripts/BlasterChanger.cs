using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlasterChanger : MonoBehaviour
{

    public Sprite stageOneBlaster;
    public Sprite stageTwoBlaster;
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
        if (ScoreManager.instance.score >= 50)
        {
            spriteRenderer.sprite = stageTwoBlaster;
            fireController.fireRate = 0.01f;
        }
    }
}
