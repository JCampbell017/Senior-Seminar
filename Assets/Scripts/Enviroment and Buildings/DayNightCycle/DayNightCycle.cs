using System.Collections;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public bool haveDayNightCycle = true;
    public float dayLengthInSeconds = 5f;
    public float dayInitial = .25f;
    public Transform sunTransform;

    private float sunRefreshRate;
    private float rotationAngleStep;
    private Vector3 rotationAxis;

    private void Awake()
    {
        sunTransform.rotation = Quaternion.Euler(dayInitial * 360f, -30f,0f);
        sunRefreshRate = 0.1f;
        rotationAxis = sunTransform.right;
        rotationAngleStep = 360f * sunRefreshRate / dayLengthInSeconds;
    }

    private void Start()
    {
        StartCoroutine("UpdateSun");
    }

    private IEnumerator UpdateSun()
    {
        while (true)
        {
            sunTransform.Rotate(rotationAxis, rotationAngleStep, Space.World);

            yield return new WaitForSeconds(sunRefreshRate);
        }
    }
}