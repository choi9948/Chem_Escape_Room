/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Beaker2 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

        [SerializeField] private GameObject inputPanel;
        [SerializeField] InputField inputField;
        [SerializeField] Text resultText;
        [SerializeField] string objectInteractMessage;
        [SerializeField] private OxidationFlowReactor oxidationFlowReactor;
        [SerializeField] private TextMeshPro labelText;

        private void Start()
        {
            labelText.gameObject.SetActive(true);
            inputPanel.SetActive(true);
        }

        public void SetLabel(string label)
        {
            labelText.gameObject.SetActive(true);
            labelText.text = label;
        }

        public void ValidateInput()
        {
            string input = inputField.text;
            if (input == "propanal")
            {
                resultText.text = "Correct Label";
                resultText.color = Color.green;
                objectInteractMessage = "Labelled Correctly";
                hasInteracted = true;
                SetLabel(input);
            }
            else
            {
                resultText.text = "Incorrect Label";
                resultText.color = Color.red;
                objectInteractMessage = "Incorrect Label";
            }
            inputPanel.SetActive(false);
        }

        public void Interact()
        {
            if (!hasInteracted)
            {

                if (oxidationFlowReactor.HasBeenOxidized)//if holding object
                {
                    labelText.gameObject.SetActive(true);
                    inputPanel.SetActive(true);
                    inputField.interactable = true;
                    inputField.ActivateInputField();
                    objectInteractMessage = "Enter Label.";
                }
                else
                {
                    objectInteractMessage = "Controlled Oxidation has not occured";
                }
            }
            else
            {
                objectInteractMessage = "Already Labeled.";
            }
            objectInteractMessage = "Label Chemical [E]";
        }

        public void OnSubmitLabel()
        {
        ValidateInput();
        }
    }
}
*/

using System.Text;
using UnityEngine;
using TMPro;

namespace DefaultNamespace
{
    public class Beaker2 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

       
        [SerializeField] private TextMeshProUGUI inputDisplayText; // UI text showing what player types
        [SerializeField] private TextMeshProUGUI resultText;       // UI text showing validation result
        [SerializeField] private TextMeshPro labelText;            // Label on the beaker
        [SerializeField] private OxidationFlowReactor oxidationFlowReactor;
        [SerializeField] private InputManager playerMovement;    // Reference to your WASD controller script

        private bool isTyping = false;
        private StringBuilder currentInput = new StringBuilder();
        private string objectInteractMessage = "Label Chemical [E]";

        private void Start()
        {
            labelText.gameObject.SetActive(true);
            inputDisplayText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(false);
        }

        public void SetLabel(string label)
        {
            labelText.text = label;
        }

        private void Update()
        {
            // Start interaction when player presses E
            if (Input.GetKeyDown(KeyCode.E) && !isTyping)
            {
                if (hasInteracted)
                {
                    objectInteractMessage = "Already Labeled.";
                    return;
                }

                if (!oxidationFlowReactor.HasBeenOxidized)
                {
                    objectInteractMessage = "Controlled Oxidation has not occurred";
                    return;
                }

                StartTyping();
            }

            if (isTyping)
            {
                HandleTyping();
            }
        }

        private void StartTyping()
        {
            isTyping = true;
            currentInput.Clear();
            inputDisplayText.text = "";
            inputDisplayText.gameObject.SetActive(true);
            resultText.gameObject.SetActive(false);
            objectInteractMessage = "Enter Label:";

            // Disable player movement (WASD)
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
            }
        }

        private void StopTyping()
        {
            isTyping = false;
            inputDisplayText.gameObject.SetActive(false);

            // Re-enable player movement
            if (playerMovement != null)
            {
                playerMovement.enabled = true;
            }
        }

        private void HandleTyping()
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b') // Backspace
                {
                    if (currentInput.Length > 0)
                    {
                        currentInput.Remove(currentInput.Length - 1, 1);
                    }
                }
                else if (c == '\n' || c == '\r') // Enter key
                {
                    ValidateInput();
                    StopTyping();
                    return;
                }
                else
                {
                    currentInput.Append(c);
                }
            }

            inputDisplayText.text = currentInput.ToString();
        }

        private void ValidateInput()
        {
            string input = currentInput.ToString().ToLower().Trim();

            if (input == "propanal")
            {
                resultText.text = "Correct Label";
                resultText.color = Color.green;
                objectInteractMessage = "Labelled Correctly";
                hasInteracted = true;
                SetLabel(input);
                inputDisplayText.gameObject.SetActive(false);
                resultText.gameObject.SetActive(false);
            }
            else
            {
                resultText.text = "Incorrect Label";
                resultText.color = Color.red;
                objectInteractMessage = "Incorrect Label";
            }
        }


        public void Interact()
        {
            if (!hasInteracted)
            {

                if (oxidationFlowReactor.HasBeenOxidized)//if holding object
                {
                    objectInteractMessage = "Enter Label.";
                }
                else
                {
                    objectInteractMessage = "Controlled Oxidation has not occured";
                }
            }
            else
            {
                objectInteractMessage = "Already Labeled.";
            }
        }
    }
}