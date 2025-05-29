
using UnityEngine;

public class BedTrigger : MonoBehaviour
{
    [SerializeField]
    private Bed Bed;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (!Bed.IsLooked)
            {
                Bed.Rise(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (Bed.IsLooked)
            {
                return;
            }
        }
    }
}
