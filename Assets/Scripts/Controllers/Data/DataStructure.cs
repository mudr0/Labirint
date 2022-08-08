using System;
using UnityEngine;

[Serializable]
public struct SVect3
{
    public float X;
    public float Y;
    public float Z;
    
    public SVect3(float x, float y, float z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    
    public static implicit operator Vector3(SVect3 val)
    {
        return new Vector3(val.X, val.Y, val.Z);
    }
    
    public static implicit operator SVect3(Vector3 val)
    {
        return new SVect3(val.x, val.y, val.z);
    }
}

[Serializable]
public struct SQuarter
{
    public float X;
    public float Y;
    public float Z;
    public float W;

    public SQuarter(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;
    }
    
    public static implicit operator Quaternion(SQuarter val)
    {
        return new Quaternion(val.X, val.Y, val.Z, val.W);
    }
    
    public static implicit operator SQuarter(Quaternion val)
    {
        return new SQuarter(val.x, val.y, val.z, val.w);
    }
}

[Serializable]
public struct SObject
{ 
    public string Name;
    public SVect3 Position;
    public SVect3 Scale;
    public SQuarter Rotation;

    public SObject(GameObject go)
    {
        Name = go.name;
        Position = go.transform.position;
        Scale = go.transform.localScale;
        Rotation = go.transform.rotation;
    }
}
