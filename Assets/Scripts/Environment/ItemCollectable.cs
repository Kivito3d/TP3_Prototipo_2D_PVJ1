using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Avx;

public class ItemCollectable : MonoBehaviour
{
    [Header("Item Settings")]
    [SerializeField] private ItemData itemData;
    private SpriteRenderer spriteRenderer;
    //[Header("Global References")]
    //[SerializeField] private PlayerStats playerStats;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = itemData.ItemIcon;
    }
    private void OnTriggerEnter2D(Collider2D collision) 
    { 
        if (collision.CompareTag("Player")) 
        { 
            Collect(); 
        } 
    }
    private void Collect() 
    { 
        if (itemData != null /*&& playerStats != null*/) 
        {
            //playerStats.AddScore(itemData.ScoreValue);
            GameManager.Instance.NotifyUpdatePoints(itemData.ScoreValue);
            //playerStats.EnergyScore += 1;
            
            if (itemData.PickupSound != null)
            { 
                //AudioSource.PlayClipAtPoint(itemData.PickupSound, transform.position); 
            } 
        } 
        Destroy(gameObject); 
    }
}
