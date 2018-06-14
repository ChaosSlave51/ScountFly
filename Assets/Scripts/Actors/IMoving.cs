using UnityEngine;
using UnityEditor;
using System;


public interface IMoving 
{
    void StrafeHorizontal(float power);
    void StafeVertical(float power);
    void RotateTo(Vector2 newRotation);
    void Forward(float power);

}