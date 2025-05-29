using System.Collections;
using UnityEngine;

public class Bed : MonoBehaviour
{
    [SerializeField] public bool IsLooked = false;
    [SerializeField] private float Speed = 1f;

    [Header("Object to rise from bed")]
    [SerializeField] private GameObject objectToAppear;


    [Header("Rise animation settings")]
    [SerializeField] private float riseHeight = 0.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isRising = false;
    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        if (objectToAppear!= null)
        {
            startPosition = objectToAppear.transform.position;
            targetPosition = startPosition + Vector3.up * riseHeight;
            objectToAppear.SetActive(false);
        }
    }

    public void Rise(Vector3 UserPosition)
    {
        if (!IsLooked && isRising)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            objectToAppear.SetActive(true);
            AnimationCoroutine = StartCoroutine(DoRise());
        }
    }

    private IEnumerator DoRise()
    {
        IsLooked = true;
        isRising = true;

        Vector3 initialPos = objectToAppear.transform.position;
        float time = 0;

        while (time < 1)
        {
            objectToAppear.transform.position = Vector3.Lerp(initialPos, targetPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }

        objectToAppear.transform.position = targetPosition;
        isRising = false;
    }
}
