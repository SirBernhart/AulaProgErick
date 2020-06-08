using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject.SpaceFighter;

public class BaseUnit : MonoBehaviour
{
    [SerializeField] private float _speed;

    public float Speed
    {
        get => _speed;
    }

    public void MoveTowards(Vector2 destination, float speed)
    {
        if( Mathf.Abs(Vector3.Distance(this.transform.position, destination)) < 0.1 )
            return;
        Vector3.Lerp(this.transform.position, destination, speed);
    }
    

}
