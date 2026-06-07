using UnityEngine;

public class Bullet : MonoBehaviour
{
    float BULLET_SPEED = 20f;

    public AudioSource audioSource;
    public AudioClip killEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * BULLET_SPEED * Time.deltaTime);

        if (transform.position.y > 6f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            AudioSource.PlayClipAtPoint(killEnemy, transform.position);

            GameManager.Instance.AddScore();

            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
