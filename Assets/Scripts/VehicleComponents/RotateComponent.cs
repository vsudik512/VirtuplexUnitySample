using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateComponent : VehicleComponentBase
{
    public Axis RotateOnAxis;
    public float RotationDegrees;

    private Vector3 axisEuler = Vector3.zero;
    private float initAxisDegrees;
    private float currentAxisDegrees;

    private Coroutine coroutine;
    private bool isRotated = false;

    void Start()
    {

        if (RotateOnAxis == Axis.X)
        {
            axisEuler = Vector3.right;
            initAxisDegrees = transform.localEulerAngles.x;
        }
        else if (RotateOnAxis == Axis.Y)
        {
            axisEuler = Vector3.up;
            initAxisDegrees = transform.localEulerAngles.y;
        }
        else if (RotateOnAxis == Axis.Z)
        {
            axisEuler = Vector3.forward;
            initAxisDegrees = transform.localEulerAngles.z;
        }

        currentAxisDegrees = initAxisDegrees;
    }

    public override void InvokeInteraction()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);

        coroutine = StartCoroutine(RotateObjectCo());
    }

    private IEnumerator RotateObjectCo()
    {
        var wait = new WaitForEndOfFrame();

        float startValue = currentAxisDegrees;
        float finalValue = isRotated ? initAxisDegrees : RotationDegrees;

        isRotated = !isRotated;

        float t = 0f;
        float duration = 2f;

        while (currentAxisDegrees != finalValue)
        {
            t += Time.deltaTime / duration;
            currentAxisDegrees = Mathf.Lerp(startValue, finalValue, t);
            transform.localEulerAngles = axisEuler * currentAxisDegrees;

            yield return wait;
        }
    }
}

public enum Axis { X, Y, Z }
