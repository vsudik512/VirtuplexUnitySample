using UnityEngine;

public class ToggleComponent : VehicleComponentBase
{
    public GameObject ToggledObject;
    private bool toggled = false;

    public override void InvokeInteraction()
    {
        toggled = !toggled;
        ToggledObject.SetActive(toggled);
    }
}
