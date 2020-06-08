using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    [SerializeField] private BoxRenderer _boxRenderer;
    [SerializeField] private SelectionBox _selectionBox;
    [SerializeField] private Vector2 _startingPos;
    
    private void Update()
    {
        var inputPos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            _boxRenderer.CreateBox(inputPos);
            _selectionBox.RegisterFirstVertex(inputPos);
        }
        else if (Input.GetMouseButton(0))
        {
            _boxRenderer.UpdateBox(inputPos);
        }
        else if (Input.GetMouseButtonUp(0)) // else if MFTU (might fuck things up)  
        {
            _boxRenderer.EraseBox();
            _selectionBox.RegisterLastVertex(inputPos);
        }
    }
    
    
}
