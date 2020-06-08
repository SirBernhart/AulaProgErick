using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupHolder : MonoBehaviour
{
    private List<BaseUnit> _units;
    private Vector2 _groupCenter;
    
    public Vector2 GetCenterFromSelection(List<Vector2> selectedPositions)
    {
        var centerPos = Vector2.zero;
        foreach (var unit in selectedPositions)
        {
            centerPos += unit;
        }
        centerPos /= selectedPositions.Count;

        return centerPos;
    }

    private void MoveGroupTowards(Vector2 destination, List<BaseUnit> selectedList)
    {
        var groupSpeed = GetLowestSpeed();
        // var direction = GetMovementDirection(currentPosition, destination);
        
        foreach (var unit in selectedList)
        {
            unit.MoveTowards(destination, groupSpeed);
        }
    }

    public void StoreSelection(List<BaseUnit> selectedList)
    {
        _units = selectedList;
    }
    
    public void EraseSelection()
    {
        _units = new List<BaseUnit>();
    }

    // private Vector2 GetMovementDirection(Vector2 currPos, Vector2 finalPos)
    // {
    //     var directionNormalized = finalPos - currPos;
    //     directionNormalized.Normalize();
    //     return directionNormalized;
    // }
    
    
    private float GetLowestSpeed()
    {
        if (_units.Count == 0)
            return 0;
        if (_units.Count == 1)
            return _units[0].Speed;

        var slowest = 0.0f;
        foreach (var unit in _units)
        {
            if (unit.Speed < slowest)
                slowest = unit.Speed;
        }
        return slowest;
    }

}