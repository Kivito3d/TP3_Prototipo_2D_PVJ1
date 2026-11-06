using UnityEngine;

public class DoorPlatform : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;

    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if(playerStats.EnergyScore >= GameManager.Instance.RequiredPoints)
            {
                GameManager.Instance.ChangeState(GameState.Victory);
            }
            else
            {
                Debug.Log("Faltan puntos de energia");

            }
        }
    }

}
