using UnityEngine;
using static UnityEngine.CullingGroup;

public class RespawnSystem : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private PlayerStats playerStats;

    private Rigidbody2D rb;
    private Collider2D col;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col= GetComponent<Collider2D>();
        playerStats.Checkpoint = transform.position;

    }

    private void Start()
    {
        if (GameManager.Instance != null)
        {

            GameManager.Instance.OnChangeState += StateChange;

        }
    }


    private void OnDestroy()
    {
        if (GameManager.Instance != null)
        {

            GameManager.Instance.OnChangeState -= StateChange;

        }
    }


    private void StateChange(GameState value)
    {
        if(value == GameState.Start)
        {
            Respawn();
        }
    }


    public void Respawn()
    {
        transform.position = playerStats.Checkpoint;
        rb.bodyType = RigidbodyType2D.Dynamic;
        col.enabled = true;
    }
  

    public void Fall()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        col.enabled = false;
        GameManager.Instance.ChangeState(GameState.GameOver);
    }

    public void SetCheckpoint(Vector3 value)
    {
        playerStats.Checkpoint = value;
    }
}
