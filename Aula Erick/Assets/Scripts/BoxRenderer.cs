using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class BoxRenderer : MonoBehaviour
{
    private Box selection;
    [SerializeField] private Image boxGraphics;

    public void CreateBox(Vector2 pos)
    {
        selection.startingPos = pos;
        selection.finishingPos = pos;
    }

    public void UpdateBox(Vector2 pos)
    {
        if(!boxGraphics.enabled)
            boxGraphics.enabled = true;
        selection.finishingPos = pos;
        DrawBox();
    }

    private void DrawBox()
    {
        var center = (selection.finishingPos + selection.startingPos) / 2;
        var size = new Vector2(
            Mathf.Abs(selection.finishingPos.x - selection.startingPos.x),
            Mathf.Abs(selection.finishingPos.y - selection.startingPos.y)
        );
        boxGraphics.rectTransform.position = center;
        boxGraphics.rectTransform.sizeDelta = size;
    }

    public void EraseBox()
    {        
        boxGraphics.enabled = false;
    }
    
}

public struct Box
{
    public Vector2 startingPos, finishingPos;

    public Box(Vector2 startPos, Vector2 finishPos)
    {
        startingPos = startPos;
        finishingPos = finishPos;
    }
}
