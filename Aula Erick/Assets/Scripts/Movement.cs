using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform objectCenter;
    [SerializeField] private float groupMoveSpeed;
 
    private void MoveFromTo(Vector3 currentPosition, Vector3 finalPosition, List<BaseUnit> positionList)
    {
        foreach (var unit in positionList)
        {
            groupMoveSpeed = unit.Speed;
        }
        Vector3.Lerp(currentPosition, finalPosition, groupMoveSpeed);
    }

    private void FixedUpdate()
    {
        
    }
}
