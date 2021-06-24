using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    private int CurrentHealth;
    
    public Slider healthBar;
 public AudioClip dieSound;  
 private AudioSource audioSource;
 public GameObject DieScreen;

 private void Start() {
     audioSource =  GetComponent<AudioSource>();
     CurrentHealth = MaxHealth;
     healthBar.value =CurrentHealth;
}
    public void ChangeHealth(int amount)
    {
        CurrentHealth += amount;
        healthBar.value =CurrentHealth;

        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
           healthBar.value =CurrentHealth;
            // Die
            Die();
            
        }

        if (CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
            healthBar.value =CurrentHealth;
        }
    }

    public void Die()
    {
        DieScreen.SetActive(true);
         audioSource.clip = dieSound;   
         audioSource.PlayOneShot(audioSource.clip);
    }
}