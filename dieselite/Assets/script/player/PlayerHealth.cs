using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar; 
   
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TakeDamage(int Damage)
    {
        currentHealth -= Damage;
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D (Collision2D collision){
        if (collision.gameObject.tag.Equals("Bullet")){
            Destroy(collision.gameObject); 
            TakeDamage(10);
        }
    }
}
