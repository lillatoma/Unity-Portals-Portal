using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseTools
{
    static public float RealVector2Angle(Vector2 _in) //Like, why do you use weird logic, dear Vector2.Angle(...)?
    {
        float _out;
        _out = Mathf.Atan2(_in.y, _in.x);
        return _out;
    }
}
