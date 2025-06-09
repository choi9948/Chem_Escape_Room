using UnityEngine;
using TMPro;

namespace DefaultNamespace
{
    public class Chalk : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject spawnPrefab;

        [Header("UI")]
        [SerializeField] private TMP_InputField passwordInputField;
        [SerializeField] private GameObject passwordPanel;

        public void Start()
        {
            passwordPanel.SetActive(false); 
        }
        void Spawn()
        {
            spawnPrefab.transform.position = transform.position + Vector3.up + new Vector3(0, 0, 3f);
            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
        }

        public void Submit()
        {
            string password = passwordInputField.text.Trim();
            if (password == "13245")
            {
                Spawn();
                objectInteractMessage = "Unlocked.";
                hasInteracted = true;
                passwordPanel.SetActive(false);
                Time.timeScale = 1f;
            }
            else
            {
                objectInteractMessage = "Incorrect Password.";
            }
        }
        public void Interact()
        {
            if (!hasInteracted)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                passwordPanel.SetActive(true); // Show the input UI
                passwordInputField.text = "";
            }
            else
            {
                objectInteractMessage = "Already Opened.";
            }
        }
    }
}