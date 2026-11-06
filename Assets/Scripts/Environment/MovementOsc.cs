using UnityEngine;

public class MovementOsc : MonoBehaviour
{

    [SerializeField] private float frequency;
    [SerializeField] private float amplitude;
    //[SerializeField] private float velocity;

    [SerializeField] private EnemyData enemyData;
    private SpriteRenderer spriteRenderer;

    private Vector3 move;

    private Vector3 initPosition;
    void Start()
    {
        initPosition = GetComponent<Transform>().position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(enemyData != null)
        {
            frequency = enemyData.Speed;
        }
    }

    void Update()
    {
        float avanceX = Mathf.Sin(Time.time * frequency) * amplitude;
        move = new Vector3(avanceX, 0f);

        float dir = Mathf.Cos(Time.time * frequency);
        spriteRenderer.flipX = dir > 0f;

        transform.position = new Vector3(initPosition.x + move.x, initPosition.y, initPosition.z);
    }
}
