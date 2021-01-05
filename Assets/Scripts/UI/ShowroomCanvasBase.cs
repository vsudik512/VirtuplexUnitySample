using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShowroomCanvasBase : MonoBehaviour
{
    public ShowroomVehicle vehicleScript;

    public virtual void Initialize(ShowroomVehicle vehicle)
    {
        vehicleScript = vehicle;
        SetupLogic();
    }

    protected abstract void SetupLogic();
}
