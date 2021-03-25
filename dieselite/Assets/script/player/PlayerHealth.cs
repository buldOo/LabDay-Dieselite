using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public static PlayerHealth instance;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("Il  y a plus d'une instance de player dans la scène");
            return;
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth == 0) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void HealPlayer(int amount)
    {
        if((currentHealth += amount) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        healthBar.SetHealth(currentHealth);
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
