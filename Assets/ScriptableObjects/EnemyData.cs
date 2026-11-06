using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Stats/EnemyData")]
public class EnemyData : ScriptableObject
{
    [Header("Enemy Data")]
    [SerializeField] private string enemyName = "Robot";
    [SerializeField] private Sprite enemyIcon;
    [SerializeField] private AnimatorController enemyController;
    [SerializeField] private int damage = 10;
    [SerializeField] private AudioClip enemySound;
    [SerializeField] private GameObject vfxPrefab;

    [SerializeField] private float shootFrequency;
    [SerializeField] private float speed;
    // Propiedades
    public string EnemyName => enemyName;
    public Sprite EnemyIcon => enemyIcon;
    public AnimatorController EnemyController => enemyController;
    public int Damage => damage;
    public float ShootFrequency => shootFrequency;
    public AudioClip EnemySound => enemySound;
    public GameObject VFXPrefab => vfxPrefab;
    public float Speed => speed;
}
