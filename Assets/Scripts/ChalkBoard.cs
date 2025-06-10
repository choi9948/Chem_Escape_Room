using UnityEngine;
using UnityEngine.UI;
namespace DefaultNamespace
{
    public class Chalkboard : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;

        [SerializeField] public GameObject computerScreenUI;
        [SerializeField] public GameObject spawnPrefab;

        [Header("Blanks")]
        [SerializeField] InputField input;
        private bool hasInteracted = false;

        public void Start()
        {
            computerScreenUI.SetActive(false);
        }

        void Spawn()
        {
            spawnPrefab.transform.position = transform.position + Vector3.up + new Vector3(2f, 0, 0);
            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
        }
        public void Interact()
        {
            if (!hasInteracted)
            {
                computerScreenUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                hasInteracted = true;
            }
            else
            {
                objectInteractMessage = "Already completed";
            }
        }

        public void Check()
        {
            string userInput1 = input.text.Trim().ToLower();
            if (userInput1 == "-3292")
            {
                Cursor.visible = false;
                computerScreenUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                Spawn();
                objectInteractMessage = "Completed";
            }
            else
            {
                return;
            }
        }
    }
}