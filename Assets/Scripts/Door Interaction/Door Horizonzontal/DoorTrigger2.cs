
using UnityEngine;

public class DoorTrigger2 : MonoBehaviour
{
    [SerializeField]
    private Door2 Door2;

    private void OnTriggerEnter2(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (!Door2.IsOpen)
            {
                Door2.Open(other.transform.position);
            }
        }
    }

    private void OnTriggerExit2(Collider other)
    {
        if (other.TryGetComponent<CharacterController>(out CharacterController controller))
        {
            if (Door2.IsOpen)
            {
                Door2.Close();
            }
        }
    }
}
