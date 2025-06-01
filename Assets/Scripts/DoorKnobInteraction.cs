using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorKnobInteraction : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

        [SerializeField]
        GameObject knob;

        [SerializeField] string objectInteractMessage;

        private void Transition()
        {
            SceneManager.LoadScene("NextScene");
        }

        void Start()
        {
           
        }
    


        public void Interact()
        {
            if (!hasInteracted)
            {

                if (knob != null)//if holding object)
                {
                    Transition();
                    objectInteractMessage = "Door Opened";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing door knob.";
                }
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }
        
    }
}