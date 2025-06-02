using TMPro;
using UnityEngine;
using System.Collections; // <-- Add this line

public class Drawer : MonoBehaviour
{
    public bool IsOpen = false;

    [SerializeField] private float Speed = 1f;
    [SerializeField] private float SlideAmount = 1.9f;
    [SerializeField] private Vector3 SlideDirection = Vector3.back;

    private Vector3 StartPosition;
    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        StartPosition = transform.position;
    }

    public void Open()
    {
        if (!IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            AnimationCoroutine = StartCoroutine(DoSlidingOpen());
        }
    }

    private IEnumerator DoSlidingOpen()
    {
        Vector3 endPosition = StartPosition + SlideAmount * SlideDirection;
        Vector3 startPosition = transform.position;

        float time = 0f;
        IsOpen = true;

        while (time < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }

        transform.position = endPosition;
    }

    public void Close()
    {
        if (IsOpen)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }
            AnimationCoroutine = StartCoroutine(DoSlidingClose());
        }
    }

    private IEnumerator DoSlidingClose()
    {
        Vector3 endPosition = StartPosition;
        Vector3 startPosition = transform.position;
        float time = 0f;

        IsOpen = false;

        while (time < 1f)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, time);
            yield return null;
            time += Time.deltaTime * Speed;
        }

        transform.position = endPosition;
    }
}
