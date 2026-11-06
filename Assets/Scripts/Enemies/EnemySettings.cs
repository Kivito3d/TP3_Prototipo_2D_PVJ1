using UnityEngine;

public class EnemySettings : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private EnemyData enemyData;

     private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        

        spriteRenderer.sprite = enemyData.EnemyIcon;
        animator.runtimeAnimatorController = enemyData.EnemyController;
    }



}
