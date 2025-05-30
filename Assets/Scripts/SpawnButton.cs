using UnityEngine;

namespace DefaultNamespace
{
    public class SpawnButton : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

        [SerializeField] GameObject spawnPrefab;

        [SerializeField] string objectInteractMessage;



        void Spawn()
        {
            var spawnedObject = Instantiate(spawnPrefab, transform.position + Vector3.up, Quaternion.identity);
            //spawnedObject.transform.position = transform.position + Vector3.up;
            Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                Spawn();
                hasInteracted = true;
            }
            else
            {
                objectInteractMessage = "Already inspected.";
            }
        }
    }
}