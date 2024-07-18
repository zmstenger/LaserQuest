using System;
using _app.Scripts.Manager;
using Unity.VisualScripting;
using UnityEngine;

namespace _app.Scripts.TriggerExamples
{
    public class TriggerBox : MonoBehaviour
    {
        [SerializeField] public int scoreAmount;
        public void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                if (AudioManager.instance != null && GameManager.instance !=null)
                {
                    AudioManager.instance.PlayAudio();
                    // GameManager.instance.playerScore++;
                    Destroy(this.gameObject);
                    GameManager.instance.ChangeScore(scoreAmount);
                    
                }
                else
                {
                    Debug.Log("Player Entered Trigger, No AudioManager");
                }

            }
        }
        public void OnTriggerExit(Collider other)
        {
            Debug.Log(other.transform.name + " Exited Trigger");
        }
        
        public void OnCollisionEnter(Collision other)
        {
           
        }
        
        public void OnCollisionExit(Collision other)
        {
            Debug.Log("No Longer Colliding With Object");
        }

     
    }
}