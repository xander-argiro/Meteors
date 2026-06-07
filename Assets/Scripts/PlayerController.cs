using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    Vector2 moveInput;
    float MOVE_SPEED = 5f;

    float MIN_X = -2.3f;
    float MAX_X = 2.3f;
    float MIN_Y = -3.5f;
    float MAX_Y = 0f;

    public GameObject bullet;
    public Transform firePoint;

    float fireRate = 0.2f;
    float nextFireTime = 0f;

    public Image[] healthIcons;
    public int health = 3;

    public bool isAlive = true;

    public AudioSource audioSource;
    public AudioClip shootClip;

    public SpriteRenderer playerSprite;

    public void OnMove(InputValue value)
    {
        if (!isAlive)
        {
            return;
        }

        moveInput = value.Get<Vector2>();
    }

    public void OnAttack()
    {
        if ((Time.time >= nextFireTime) && isAlive)
        {
            audioSource.PlayOneShot(shootClip);

            Instantiate(bullet, firePoint.position, firePoint.rotation);
            nextFireTime = Time.time + fireRate;
        }    
    }

    public void TakeDamage()
    {
        if (health <= 0)
        {
            isAlive = false;
            moveInput = Vector2.zero;

            playerSprite.enabled = false;

            GameManager.GameOver();
            UpdateHealthUI();
            return;
        }
        health--;
        UpdateHealthUI();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void UpdateHealthUI()
    {
        for (int i = 0; i < healthIcons.Length; i++)
        {
            healthIcons[i].enabled = i < health;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            TakeDamage();
        }

        Vector3 movement = new Vector3(moveInput.x, moveInput.y, 0f);
        transform.position += movement * MOVE_SPEED * Time.deltaTime;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, MIN_X, MAX_X);
        pos.y = Mathf.Clamp(pos.y, MIN_Y, MAX_Y);

        transform.position = pos;
    }
}
