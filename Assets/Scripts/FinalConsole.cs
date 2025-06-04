using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
namespace DefaultNamespace
{
    public class FinalConsole : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;

        [Header("Setup")]
            
        [SerializeField] private GameObject beaker1;
        [SerializeField] private GameObject beaker2;
        [SerializeField] private GameObject slot;
        [SerializeField] private MonoBehaviour playerMovementScript;

        [Header("UI")]
        [SerializeField] private TextMeshProUGUI promptText;
        [SerializeField] private TextMeshProUGUI inputDisplayText;

        private string objectInteractMessage = "Pass Security [E]";
        private string currentInput = "";

        private bool hasInteracted = false;
        private bool isTyping = false;
        private bool waitingForReactant = false;
        private bool waitingForReaction = false;

        private string correctReactant = "dimethylamine";
        private string correctReaction = "amide reaction";

        private void Update()
        {
            if (isTyping)
            {
                foreach (char c in Input.inputString)
                {
                    if (c == '\b' && currentInput.Length > 0)
                    {
                        currentInput = currentInput.Substring(0, currentInput.Length - 1);
                    }
                    else if ((c == '\n' || c == '\r') && currentInput.Length > 0)
                    {
                        ValidateInput();
                    }
                    else if (!char.IsControl(c))
                    {
                        currentInput += c;
                    }
                }

                inputDisplayText.text = currentInput;
            }
        }

        public void Interact()
        {
            if (hasInteracted)
            {
                objectInteractMessage = "Already unlocked.";
                UpdatePrompt();
                return;
            }

            if (!IsTouching(beaker1, slot) || !IsTouching(beaker2, slot))
            {
                objectInteractMessage = "Missing Propanoic Acid and N,N-dimethylpropanamide in Exit Slot.";
                UpdatePrompt();
                return;
            }

            if (!isTyping)
            {
                StartTyping("With the product and reactant inserted, what is the other reactant?");
                waitingForReactant = true;
            }
        }

        private void StartTyping(string message)
        {
            isTyping = true;
            currentInput = "";
            objectInteractMessage = message;
            inputDisplayText.text = "";
            inputDisplayText.gameObject.SetActive(true);
            UpdatePrompt();
            DisableMovement();
        }

        private void StopTyping()
        {
            isTyping = false;
            inputDisplayText.gameObject.SetActive(false);
            EnableMovement();
        }

        private void ValidateInput()
        {
            string input = currentInput.ToLower().Trim();

            if (waitingForReactant)
            {
                if (input == correctReactant)
                {
                    waitingForReactant = false;
                    waitingForReaction = true;
                    StartTyping("Correct. What type of reaction is this?");
                }
                else
                {
                    StartTyping("Incorrect reactant. Try again.");
                }
            }
            else if (waitingForReaction)
            {
                if (input == correctReaction)
                {
                    objectInteractMessage = "Correct! Unlocking door...";
                    UpdatePrompt();
                    hasInteracted = true;
                    StopTyping();
                    Invoke(nameof(LoadNextScene), 2f);
                }
                else
                {
                    StartTyping("Incorrect reaction type. Try again.");
                }
            }
        }

        private void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private bool IsTouching(GameObject obj1, GameObject obj2)
        {
            if (obj1 == null || obj2 == null) return false;
            Collider c1 = obj1.GetComponent<Collider>();
            Collider c2 = obj2.GetComponent<Collider>();
            if (c1 == null || c2 == null) return false;
            return c1.bounds.Intersects(c2.bounds);
        }

        private void UpdatePrompt()
        {
            if (promptText != null)
                promptText.text = objectInteractMessage;
        }

        private void DisableMovement()
        {
            if (playerMovementScript != null)
                playerMovementScript.enabled = false;
        }

        private void EnableMovement()
        {
            if (playerMovementScript != null)
                playerMovementScript.enabled = true;
        }
    }
}