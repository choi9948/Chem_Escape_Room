using UnityEngine;

public class Bed : MonoBehaviour
{
    public bool IsLooked = false;
    [SerializeField]

    [Header("Object to rise from bed")]
    [SerializeField] private GameObject objectToAppear;

    [Header("Rise animation settings")]
    [SerializeField] private float riseHeight = 0.5f;
    [SerializeField] private float riseDuration = 1.5f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private bool isRising = false;
    private Coroutine AnimationCoroutine;

    private void Awake()
    {
        if (objectToAppear != null)
        {
            startPosition = objectToAppear.transform.position;
            targetPosition = startPosition + Vector3.up * riseHeight;
            objectToAppear.SetActive(false);
        }
    }

    public void Rise()
    {
        if (!IsLooked)
        {
            if (AnimationCoroutine != null)
            {
                StopCoroutine(AnimationCoroutine);
            }

            if (!isRising)
            {
                AnimationCoroutine = StartCoroutine(DoRise);
            }
        }
    }

    private IEnumerator DoRise()
    {
        IsLooked = true;

        float time = 0;
        while (time < 1)
        {
            transform.
        }
    }
}
