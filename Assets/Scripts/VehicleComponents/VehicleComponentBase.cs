using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VehicleComponentBase : MonoBehaviour
{
    public VehicleComponentType componentType;

    public abstract void InvokeInteraction();
}

public enum VehicleComponentType
{
    FLDoor,
    FRDoor,
    RLDoor,
    RRDoor,
    TailGate,
    FrontLights,
    RearLights
}