using UnityEngine;

public class StaticShooter : MonoBehaviour
{
    [Header("Referencias")]
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public Transform player;

    [Header("Configuración")]
    public float fireRate = 1.5f;     
    public float bulletDirection = -1f;
    public float visionRange = 13f;

    private float timer;
    private Animator anim;
    private bool playerInSight;

    void Start()
    {
        anim = GetComponent<Animator>();
        if (player == null) player = GameObject.FindGameObjectWithTag("Player")?.transform;
    }

    void Update()
    {
        CheckPlayerVisibility();

        if (playerInSight)
        {
            timer += Time.deltaTime;
            if (timer >= fireRate)
            {
                Shoot();
                timer = 0;
            }
        }
        else
        {
            timer = 0; 
        }
    }

    void CheckPlayerVisibility()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        
        if (distanceToPlayer <= visionRange)
        {
            if (!playerInSight)
            {
                playerInSight = true;
                if (anim != null) anim.SetBool("IsAlert", true);
            }
        }
        else
        {
            if (playerInSight)
            {
                playerInSight = false;
                if (anim != null) anim.SetBool("IsAlert", false);
            }
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        if (anim != null) anim.SetTrigger("Shoot");

        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet scriptBala = newBullet.GetComponent<Bullet>();
        
        if (scriptBala != null)
        {
            scriptBala.SetDirection(bulletDirection);
            Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, visionRange);
    }
}