using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [Header ("Health")]
    [SerializeField] private float startingHeath;
    public float currentHealth { get; private set; }
    private Rigidbody2D rb;
    private Animator anim;
    private bool dead;
    public float _hurt;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private AudioSource hurtSoundEffect;
    [SerializeField] private AudioSource healthCollectionSoundEffect;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuaration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        currentHealth = startingHeath;
    }

    public void TakeDamage(float _hurt)
    {
        currentHealth = Mathf.Clamp(currentHealth - _hurt, 0, startingHeath);

        if (currentHealth > 0)
        {
            anim.SetTrigger("hurt");
            StartCoroutine(Invunerability());
            hurtSoundEffect.Play();
        }
        else
        {
            if (!dead)
            {
                Die();
                GetComponent<PlayerMovement>().enabled = false;              
                dead = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap") || collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(_hurt);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            Die();
        }
        if(other.gameObject.CompareTag("trap"))
            TakeDamage(_hurt);
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("die");
        RestartLevel();
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    public void AddHealth(float _value)
    {
        currentHealth = Mathf.Clamp(currentHealth + _value, 0, startingHeath);
        healthCollectionSoundEffect.Play();
    }

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(7, 8, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuaration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuaration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }
}
