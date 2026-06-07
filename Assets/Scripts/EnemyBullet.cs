using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed = 7f;

    public AudioSource audioSource;
    public AudioClip hitPlayer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(hitPlayer, transform.position);

            PlayerController player = other.GetComponent<PlayerController>();
            player.TakeDamage();

            Destroy(gameObject);
        }
    }
}
