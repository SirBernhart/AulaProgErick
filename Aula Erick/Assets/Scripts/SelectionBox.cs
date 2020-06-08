using System;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{
    [SerializeField] private Box selection;
    [SerializeField] private BoxCollider2D _mycollider;
    [SerializeField] private GroupHolder _holder;

    private void Awake()
    {
        if (_mycollider == null)
            GetComponent<BoxCollider2D>();
    }

    public void RegisterFirstVertex(Vector2 pos)
    {
        selection.startingPos = Camera.main.ScreenToWorldPoint(pos);
    }

    public void RegisterLastVertex(Vector2 pos)
    {
        selection.finishingPos = Camera.main.ScreenToWorldPoint(pos);
        RefreshBoxBoundaries();
        SelectInside();
    }

private void RefreshBoxBoundaries()
    {
        _mycollider.offset = (selection.startingPos + selection.finishingPos) / 2;
        _mycollider.size = new Vector2(
            Mathf.Abs(selection.finishingPos.x - selection.startingPos.x),
            Mathf.Abs(selection.finishingPos.y - selection.startingPos.y)
        );
    }
    
    private void SelectInside()
    {
        var insideList = new List<Collider2D>();
        _mycollider.OverlapCollider(new ContactFilter2D(), insideList);

        Debug.Log("There are " + insideList.Count + " objects inside your collider");
        
        var posList = new List<Vector2>();

        foreach (var box in insideList)
            posList.Add(box.transform.position);
        
        // _holder.GetCenterFromSelection(posList);
    }
}