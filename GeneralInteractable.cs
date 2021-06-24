using UnityEngine;
using UnityEngine.Events;


public class GeneralInteractable : MonoBehaviour
{

    public bool IsPlayerInside;
    public UnityEvent OnInteractedOR;
    public UnityEvent OnInteracted;
    public UnityEvent OnPlayerStay;
    public UnityEvent OnPlayerEnter;

    public UnityEvent OnPlayerExit;

    public UnityEvent onCollisionEnter;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsPlayerInside = true;
            OnPlayerStay.Invoke();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsPlayerInside = true;
            OnPlayerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            IsPlayerInside = false;
            OnPlayerExit.Invoke();
        }
    }
    private void OnCollisionEnter(Collision other)
    {
      
            onCollisionEnter.Invoke();
        
    }

    private void Update()
    {
        // if the player is inside AND when i press E it opens the door
        if (IsPlayerInside && Input.GetKeyDown(KeyCode.E))
        {
            OnInteracted.Invoke();
        }


    }

    private void iteractor()
    {

        if (Input.GetKeyDown(KeyCode.E))

            OnInteractedOR.Invoke();


    }



}