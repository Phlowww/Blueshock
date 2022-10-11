using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.Netcode;

public class PlayerCameraSelect : NetworkBehaviour
{

    private CinemachineVirtualCamera vcam;
    public NetworkManager networkManager;
    private NetworkObject player;
    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        vcam = GetComponent<CinemachineVirtualCamera>();
        
    }

    // Update is called once per frame
    void Update()
    {

        

            if (player == null)
            {
                player = networkManager.LocalClient.PlayerObject;

            }
            if (player != null)
            {
                playerTransform = player.transform;
                vcam.LookAt = playerTransform;
                vcam.Follow = playerTransform;
            }
        






    }
}
