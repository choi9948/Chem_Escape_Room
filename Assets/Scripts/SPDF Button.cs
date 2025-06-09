using UnityEngine;
namespace DefaultNamespace
{
    public class SPDFButton : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        public bool hasInteracted = false;

        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject key;

        // Single Arrowed Blocks
        [Header("Double Arrowed Blocks")]
        [SerializeField] GameObject block1d;
        [SerializeField] GameObject block2d;
        [SerializeField] GameObject block3d;
        [SerializeField] GameObject block4d;
        [SerializeField] GameObject block5d;
        [SerializeField] GameObject block6d;
        [SerializeField] GameObject block7d;
        [SerializeField] GameObject block8d;
        [SerializeField] GameObject block9d;
        [SerializeField] GameObject block10d;
        [SerializeField] GameObject block11d;
        [SerializeField] GameObject block12d;
        [SerializeField] GameObject block13d;
        [SerializeField] GameObject block14d;

        // Double Arrowed Blocks
        [Header("Single Arrowed Blocks")]
        [SerializeField] GameObject block1s;
        [SerializeField] GameObject block2s;
        [SerializeField] GameObject block3s;
        [SerializeField] GameObject block4s;

        private PlayerPickUpDrop playerPickUpDrop;
        private GameObject[] singleArrowBlocks;
        private GameObject[] doubleArrowBlocks;

        void Spawn()
        {
            foreach (GameObject block in singleArrowBlocks)
            {
                block.transform.position = transform.position + Vector3.up;
                Rigidbody rb1 = block.GetComponent<Rigidbody>();
            }

            foreach (GameObject block in doubleArrowBlocks)
            {
                block.transform.position = transform.position + Vector3.up;
                Rigidbody rb2 = block.GetComponent<Rigidbody>();
            }
        }

        void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
            singleArrowBlocks = new GameObject[] { block1s, block2s, block3s, block4s };
            doubleArrowBlocks = new GameObject[] { block1d, block2d, block3d, block4d, block5d, block6d, block7d, block8d, block9d, block10d, block11d, block12d, block13d, block14d };
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == key)
                {
                    Spawn();
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing Key.";
                }
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }
    }
}