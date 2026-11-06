using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "Items/ItemData")]
public class ItemData : ScriptableObject
{
    [Header("Item Data")]
    [SerializeField] private string itemName = "Energy Score";
    [SerializeField] private Sprite itemIcon; 

    [Header("Collect Settings")]
    [SerializeField] private int scoreValue = 50; 
    [SerializeField] private int healthRestoreValue = 0; 
    [Header("Feedback")]
    [SerializeField] private AudioClip pickupSound; 
    [SerializeField] private GameObject pickupVFXPrefab; 

    // Propiedades
    public string ItemName => itemName; 
    public Sprite ItemIcon =>itemIcon; 
    public int ScoreValue => scoreValue; 
    public int HealthRestoreValue => healthRestoreValue; 
    public AudioClip PickupSound => pickupSound; 
    public GameObject PickupVFXPrefab => pickupVFXPrefab;
}
