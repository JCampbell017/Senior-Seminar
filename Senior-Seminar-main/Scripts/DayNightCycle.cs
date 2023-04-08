using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool haveDayNightCycle = true;
    public float dayLengthInSeconds = 5f;
    public float dayInitialRatio = .25f;
    public Transform sTransform = null;

    private float _sRefreshRate;
    private float _rotationAngleStep;
    private Vector3 _rotationAxis;

    private void Start()
    {
        sTransform.rotation = Quaternion.Euler(dayInitialRatio * 360f, -30f, 0f);
        _sRefreshRate = 0.1f;
        _rotationAxis = sTransform.right;
        _rotationAngleStep = 360f * _sRefreshRate / dayLengthInSeconds;
        StartCoroutine("_Update");
    }

    private IEnumerator _Update()
    {
        while (true)
        {
            sTransform.Rotate(_rotationAxis, _rotationAngleStep, Space.World);
            yield return new WaitForSeconds(_sRefreshRate);
        }
    }
}
