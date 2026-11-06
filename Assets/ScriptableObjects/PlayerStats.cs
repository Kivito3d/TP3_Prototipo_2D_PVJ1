using System;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Stats/PlayerStats")]
public class PlayerStats : ScriptableObject
{
    [Header("Stats")]
    [SerializeField]private float maxHealth = 100f;
    [SerializeField] private float currentHealth;
    [SerializeField] private int currentScore = 0;

    [SerializeField] private int initialEnergyScore = 0;
    [SerializeField] private int energyScore = 0;

    [SerializeField] private float speedPlatform;
    [SerializeField] private float jumpForce;
    [SerializeField] private float speedTopDown;
    [SerializeField] private float speedShipSpace;

    [SerializeField] private Vector3 checkpoint;

    [Header("Settings Sprites")]
    [SerializeField] private Sprite platformSprite;
    public int collectables;

    public float MaxHealth => maxHealth; 
    public float CurrentHealth => currentHealth; 
    public int CurrentScore => currentScore; 
    public float SpeedPlatform => speedPlatform; 
    public float JumpForce => jumpForce;
    public int InitialEnergyScore => initialEnergyScore;
    public Vector3 Checkpoint
    {
        get { return checkpoint; }
        set { checkpoint = value; }
    }

    public int EnergyScore
    {
        get { return energyScore; }
        set { energyScore = value; }
    }

    public event Action OnStatsChanged;
    public void ResetStats()
    {
        currentHealth = maxHealth; 
        currentScore = 0;
        energyScore = 0;
        NotifyStatsChanged();

    }

    public void TakeDamage(int amount) 
    { 
        currentHealth = Mathf.Clamp(currentHealth - amount, 0, maxHealth); 
        NotifyStatsChanged(); 
    }
    public void Heal(int amount) 
    { 
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth); 
        NotifyStatsChanged(); 
    }
    public void AddScore(int amount) 
    {
        currentScore += amount;
        EnergyScore += 1;
        NotifyStatsChanged(); 
    }
    private void NotifyStatsChanged() 
    { 
        OnStatsChanged?.Invoke(); 
    }


}
