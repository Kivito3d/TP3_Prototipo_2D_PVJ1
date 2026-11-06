using System.Collections;
using UnityEditor.Animations;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    [SerializeField] private float speed ;
    [SerializeField] private float timeLife;
    [SerializeField] private EnemyData enemyData;
    [SerializeField]private Animator controller;
    private Collider2D colliderProjectile;
    private Rigidbody2D rb;

    void Start()
    {
        speed = enemyData.Speed;
        colliderProjectile = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DestroyObject());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
    //forward //right up
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        StartCoroutine(HitTransition(.28f));

        if (controller != null)
        {
            //Debug.Log("VFX");
            controller.SetTrigger("Hit");
        }
        controller.SetTrigger("Hit");
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<HealthSystem>().ApplyDamage(enemyData.Damage);
        }
        
        
    }

    private IEnumerator HitTransition(float value)
    {
        speed = 0f;
        colliderProjectile.enabled = false;
        rb.bodyType = RigidbodyType2D.Static;
        yield return new WaitForSeconds(value);
        Destroy(gameObject);
    }

    private IEnumerator DestroyObject()
    {

        yield return new WaitForSeconds(timeLife);
        Destroy(gameObject);
    }
}
