using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShowroomVehicle : MonoBehaviour
{
    [SerializeField]
    private Transform vehicleRoot;

    [SerializeField]
    private Material carPaintMaterial;

    [SerializeField]
    private VehicleComponentBase[] vehicleComponents;

    private ShowroomCanvas canvas;

    private void Start()
    {
        canvas = Instantiate(Resources.Load<GameObject>("Showroom/UI/CanvasShowroom")).GetComponent<ShowroomCanvas>();
        canvas.Initialize(this);
    }

    public void AddRotation(float degrees)
    {
        vehicleRoot.Rotate(Vector3.up, degrees);
    }

    public void SetRotation(float degrees)
    {
        vehicleRoot.eulerAngles = new Vector3(vehicleRoot.eulerAngles.x, degrees, vehicleRoot.eulerAngles.z);
    }

    public void ScaleModel(float scale)
    {
        vehicleRoot.parent.transform.localScale = Vector3.one * Mathf.Clamp(scale, 0.1f, 1f);
    }

    public void ChangePrimaryColor(Color color)
    {
        if (carPaintMaterial.GetColor("_Color") != null)
            carPaintMaterial.SetColor("_Color", color);
        else
            carPaintMaterial.color = color;
    }

    internal void InvokeComponent(VehicleComponentType type)
    {
        var component = vehicleComponents.First(x => x.componentType == type);
        if (component != null)
            component.InvokeInteraction();
    }
}