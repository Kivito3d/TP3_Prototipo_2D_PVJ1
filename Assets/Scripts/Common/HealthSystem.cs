using System;
using System.Collections;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
   
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private float immunityDuration = 1.5f;
    [SerializeField] private SpriteRenderer playerSprite;
    private bool isImmune = false;

    public event Action<float> OnChangeHealthPlayer;
    public void ApplyDamage(int amount)
    {
        if (isImmune || playerStats == null) return;

        playerStats.TakeDamage(amount);

        OnChangeHealthPlayer?.Invoke(playerStats.CurrentHealth);

        if (playerStats.CurrentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(ImmunityRoutine());
        }
    }
    private IEnumerator ImmunityRoutine()
    {
        isImmune = true; 
        float elapsed = 0f;
        while (elapsed < immunityDuration)
        {
            if (playerSprite != null) playerSprite.enabled = !playerSprite.enabled;
            yield return new WaitForSeconds(0.1f);
            elapsed += 0.1f;
        }
        if (playerSprite != null) playerSprite.enabled = true;
        isImmune = false;
    }
    private void Die()
    {
        Debug.Log("Jugador eliminado "); 
        if (GameManager.Instance != null) 
        { 
            GameManager.Instance.ChangeState(GameState.GameOver);
        } 
    }
    
}
