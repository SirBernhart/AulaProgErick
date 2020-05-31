using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    private Vector3 startingPos, finishingPos; 

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startingPos = Input.mousePosition;
        }
        if (Input.GetMouseButton(0))
        {
            finishingPos = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Vector2 boxSize = new Vector2(Mathf.Abs(finishingPos.x - startingPos.x), Mathf.Abs(finishingPos.y - startingPos.y));

            // precisa mudar a forma do BoxCast
            RaycastHit2D hits = Physics2D.BoxCast(startingPos, boxSize, 0, Vector2.zero);
            //Debug.Log(hits.);

            // termina seleção
        }
    }
}
