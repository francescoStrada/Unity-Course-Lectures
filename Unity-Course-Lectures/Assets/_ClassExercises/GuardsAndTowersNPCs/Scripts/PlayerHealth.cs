using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float _playerHealth = 200;
    [SerializeField] private float _perHitLoss = 5;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
            _playerHealth -= _perHitLoss;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 80, 20), "Health: " + _playerHealth);
    }
}
