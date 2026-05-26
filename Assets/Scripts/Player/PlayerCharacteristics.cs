using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }

    void Die()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //GameManager.Instance.GameOver();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 70, 200, 30), $"player health: {currentHealth}");
        //GUI.Label(new Rect(10, 100, 200, 30), $"Player dis: {distanceFromPlayer}");
    }
}
