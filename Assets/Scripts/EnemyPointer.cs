using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using Unity.Netcode;

public class EnemyPointer : NetworkBehaviour
{
    private Transform targetPosition;
    private RectTransform pointerRectTransform;
    public Transform playerPosition;
    public GameObject[] enemies;


    private void Start()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if (enemies != null)
        {
            targetPosition = GetClosestEnemy(enemies);
        }

    }
    private void Awake()
    {
        pointerRectTransform = transform.Find("Pointer").GetComponent<RectTransform>();

    }

    private void Update()
    {

        if (GameObject.FindWithTag("Enemy"))
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
        }
        if (enemies != null)
        {
            targetPosition = GetClosestEnemy(enemies);
        }

        if (targetPosition != null)
        {
            RotatePointer();
        }



        /*float borderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= borderSize || targetPositionScreenPoint.x >= Screen.width - borderSize || targetPositionScreenPoint.y <= borderSize || targetPositionScreenPoint.y >= Screen.height - borderSize;
        

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= borderSize) cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x <= Screen.width - borderSize) cappedTargetScreenPosition.x = Screen.width - borderSize;
            if (cappedTargetScreenPosition.y <= borderSize) cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y <= Screen.height - borderSize) cappedTargetScreenPosition.y = Screen.height - borderSize;

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(pointerRectTransform.localPosition.x, pointerRectTransform.localPosition.y, 0f);
        }*/
    }

    Transform GetClosestEnemy(GameObject[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = playerPosition.position;
        foreach (GameObject enemy in enemies)
        {
            if (enemy == null || currentPos == null) { return playerPosition; }
            float dist = Vector3.Distance(enemy.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = enemy.transform;
                minDist = dist;
            }
        }
        return tMin;

    }

    public void RotatePointer()
    {
        Vector3 toPosition = targetPosition.position;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);
    }


}
