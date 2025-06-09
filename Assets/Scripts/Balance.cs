using UnityEngine;
namespace DefaultNamespace
{
    public class Balance : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        public bool hasInteracted = false;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject spawnPrefab;

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

        // Position
        [Header("Positions")]

        [SerializeField] GameObject position1;
        [SerializeField] GameObject position2;
        [SerializeField] GameObject position3;
        [SerializeField] GameObject position4;
        [SerializeField] GameObject position5;
        [SerializeField] GameObject position6;
        [SerializeField] GameObject position7;

        // Lists of Blocks
        private GameObject[] singleArrowBlocks;
        private GameObject[] doubleArrowBlocks;

        void Spawn()
        {
            spawnPrefab.transform.position = transform.position + Vector3.up + new Vector3(0, 1f, 0);
            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
        }

        void Start()
        {
            singleArrowBlocks = new GameObject[] { block1s, block2s, block3s, block4s };
            doubleArrowBlocks = new GameObject[] { block1d, block2d, block3d, block4d, block5d, block6d, block7d, block8d, block9d, block10d, block11d, block12d, block13d, block14d };
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

        private int CountBlocksTouching(GameObject[] blocks, GameObject position)
        {
            int count = 0;
            foreach (GameObject block in blocks)
            {
                if (isTouching(block, position))
                    count++;
            }
            return count;
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                Check();
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }

        public void Check()
        {
            bool hasOneOnPosition1 = false;
            foreach (GameObject block in doubleArrowBlocks)
            {
                if (isTouching(block, position1))
                {
                    hasOneOnPosition1 = true;
                    break;
                }
            }

            bool hasOneOnPosition2 = false;
            foreach (GameObject block in doubleArrowBlocks)
            {
                if (isTouching(block, position2))
                {
                    hasOneOnPosition2 = true;
                    break;
                }
            }

            int countOnPosition3 = CountBlocksTouching(doubleArrowBlocks, position3);
            bool hasThreeOnPosition3 = false;
            if (countOnPosition3 == 3)
            {
                hasThreeOnPosition3 = true;
            }

            bool hasOneOnPosition4 = false;
            foreach (GameObject block in doubleArrowBlocks)
            {
                if (isTouching(block, position4))
                {
                    hasOneOnPosition4 = true;
                    break;
                }
            }

            int countOnPosition5 = CountBlocksTouching(doubleArrowBlocks, position5);
            bool hasThreeOnPosition5 = false;
            if (countOnPosition5 == 3)
            {
                hasThreeOnPosition5 = true;
            }

            bool hasOneOnPosition6 = false;
            foreach (GameObject block in singleArrowBlocks)
            {
                if (isTouching(block, position6))
                {
                    hasOneOnPosition6 = true;
                    break;
                }
            }

            int countOnPosition7 = CountBlocksTouching(doubleArrowBlocks, position7);
            bool hasFiveOnPosition7 = false;
            if (countOnPosition7 == 5)
            {
                hasFiveOnPosition7 = true;
            }

            Debug.Log("Position 1 touched: " + hasOneOnPosition1);
            Debug.Log("Position 2 count: " + hasOneOnPosition2);
            Debug.Log("Position 3 count: " + countOnPosition3);
            Debug.Log("Position 4 count: " + hasOneOnPosition4);
            Debug.Log("Position 5 count: " + countOnPosition5);
            Debug.Log("Position 6 count: " + hasOneOnPosition6);
            Debug.Log("Position 7 count: " + countOnPosition7);

            if (hasOneOnPosition1 == true && hasOneOnPosition2 == true && hasThreeOnPosition3 == true &&
                hasOneOnPosition4 == true && hasThreeOnPosition5 == true && hasOneOnPosition6 == true &&
                hasFiveOnPosition7 == true)
            {
                objectInteractMessage = "Successful";
                hasInteracted = true;
                Spawn();
            }
            else
            {
                objectInteractMessage = "Incorrect";
            }
        } 
    }
}
