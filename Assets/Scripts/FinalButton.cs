using UnityEngine;

namespace DefaultNamespace
{
    public class FinalButton : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

        [SerializeField] GameObject spawnPrefab;

        [SerializeField] string objectInteractMessage;

        // Blocks
        [SerializeField] GameObject block1;
        [SerializeField] GameObject block2;
        [SerializeField] GameObject block3;
        [SerializeField] GameObject block4;

        // Slots
        [SerializeField] GameObject slot1;
        [SerializeField] GameObject slot2;
        [SerializeField] GameObject slot3;
        [SerializeField] GameObject slot4;



        void Spawn()
        { 
            spawnPrefab.transform.position = transform.position;
            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
        }

        bool isTouching(GameObject other, GameObject target)
        {
            Collider col1 = other.GetComponent<Collider>();
            Collider col2 = target.GetComponent<Collider>();
            if (col1 == null || col2 == null)
            {
                return false;
            }
            return col1.bounds.Intersects(col2.bounds);
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                if (isTouching(block1, slot1) && isTouching(block2, slot2) && isTouching(block3, slot3) && isTouching(block4, slot4))
                {
                    Spawn();
                    objectInteractMessage = "Successful.";
                    hasInteracted = true;
                }
                else
                {
                   objectInteractMessage = "Unsuccessful."; 
                }
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }
    }
}