using UnityEngine;

public class StaticShooter : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint;     
    public float fireRate = 2f;     
    public float bulletDirection = -1f;

    private float timer;
    private Animator anim; // Referencia al Animator

    void Start()
    {
        anim = GetComponent<Animator>(); // Obtenemos el Animator al iniciar
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= fireRate)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null) return;

        // ACTIVAR ANIMACIÓN: Llama al Trigger "Shoot" en el Animator
        if (anim != null) anim.SetTrigger("Shoot");

        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet scriptBala = newBullet.GetComponent<Bullet>();
        
        if (scriptBala != null)
        {
            scriptBala.SetDirection(bulletDirection);
            Physics2D.IgnoreCollision(newBullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }
}