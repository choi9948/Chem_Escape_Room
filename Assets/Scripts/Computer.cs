using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Computer : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;

        [Header("Blanks")]
        [SerializeField] InputField input;

        [SerializeField] public GameObject computerScreenUI;
        private bool hasInteracted = false;


        public void Start()
        {
            computerScreenUI.SetActive(false);
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                computerScreenUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
            }
            else
            {
                objectInteractMessage = "Password: 7536";
            }
        }

        public void Check()
        {
            string userInput = input.text.Trim().ToLower();

            if (userInput == "8.9")
            {
                Cursor.visible = false;
                computerScreenUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                objectInteractMessage = "Completed";
                hasInteracted = true;
            }
            else
            {
                return;
            }
        }

    }
}