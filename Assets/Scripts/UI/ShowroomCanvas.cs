using System;
using UnityEngine;
using UnityEngine.UI;

public class ShowroomCanvas : MonoBehaviour
{
    private Camera cam;
    private Transform offsetTransform;

    public ShowroomVehicle vehicleScript;
    public Vector3 offset = new Vector3(4f, 2f, 0f);

    [Header("UI Elements")]

    [SerializeField]
    private Slider sliderRed;
    [SerializeField]
    private Slider sliderGreen;

    [SerializeField]
    private Slider sliderBlue;

    [Space(10f)]
    [SerializeField]
    private Slider sliderRotation;

    [SerializeField]
    private Slider sliderScale;

    [Space(10f)]
    [SerializeField]
    private Button buttonDoorFL;

    [SerializeField]
    private Button buttonDoorFR;

    [SerializeField]
    private Button buttonDoorRL;

    [SerializeField]
    private Button buttonDoorRR;

    [SerializeField]
    private Button buttonDoorTG;

    public void Initialize(ShowroomVehicle vehicle)
    {
        vehicleScript = vehicle;

        offsetTransform = new GameObject("OffsetHelper").transform;
        cam = Camera.main;

        SetupUILogic();
    }

    private void SetupUILogic()
    {
        sliderRed.minValue = 0f;
        sliderRed.maxValue = 1f;
        sliderRed.onValueChanged.AddListener(OnColorChanged);

        sliderGreen.minValue = 0f;
        sliderGreen.maxValue = 1f;
        sliderGreen.onValueChanged.AddListener(OnColorChanged);

        sliderBlue.minValue = 0f;
        sliderBlue.maxValue = 1f;
        sliderBlue.onValueChanged.AddListener(OnColorChanged);

        sliderRotation.minValue = -180f;
        sliderRotation.maxValue = 180f;
        sliderRotation.onValueChanged.AddListener(OnSliderRotationChanged);

        sliderScale.minValue = 0.1f;
        sliderScale.maxValue = 1f;
        sliderScale.value = 1f;
        sliderScale.onValueChanged.AddListener(OnSliderScaleChanged);

        buttonDoorFL.onClick.RemoveAllListeners();
        buttonDoorFL.onClick.AddListener(() => { vehicleScript.InvokeComponent(VehicleComponentType.FLDoor); });

        buttonDoorFR.onClick.RemoveAllListeners();
        buttonDoorFR.onClick.AddListener(() => { vehicleScript.InvokeComponent(VehicleComponentType.FRDoor); });

        buttonDoorRL.onClick.RemoveAllListeners();
        buttonDoorRL.onClick.AddListener(() => { vehicleScript.InvokeComponent(VehicleComponentType.RLDoor); });

        buttonDoorRR.onClick.RemoveAllListeners();
        buttonDoorRR.onClick.AddListener(() => { vehicleScript.InvokeComponent(VehicleComponentType.RRDoor); });

        buttonDoorTG.onClick.RemoveAllListeners();
        buttonDoorTG.onClick.AddListener(() => { vehicleScript.InvokeComponent(VehicleComponentType.TailGate); });
    }

    private void Update()
    {
        offsetTransform.position = cam.transform.position;
        offsetTransform.LookAt(vehicleScript.transform);
        transform.position = (Vector3.up * offset.y) + vehicleScript.transform.position + (offsetTransform.right * offset.x);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, cam.transform.eulerAngles.y, transform.eulerAngles.z);
    }

    private void OnColorChanged(float value)
    {
        var col = new Color(sliderRed.value, sliderGreen.value, sliderBlue.value);
        vehicleScript.ChangePrimaryColor(col);
    }

    private void OnSliderScaleChanged(float scale)
    {
        vehicleScript.ScaleModel(scale);
    }

    private void OnSliderRotationChanged(float degrees)
    {
        vehicleScript.SetRotation(degrees);
    }
}
