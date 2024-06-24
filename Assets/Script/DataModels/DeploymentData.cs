using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct DeploymentData
{
    public Vector3 WorldPosition;
    public Vector2Int XY; // Meaning it will only ended up in int figure, no float
    public bool CanDeploy;
}

