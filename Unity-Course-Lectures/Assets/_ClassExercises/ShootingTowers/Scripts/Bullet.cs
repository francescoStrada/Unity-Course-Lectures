using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _destroyIntoPieces = 40;
    [SerializeField] private float _explosionForce = 20f;
    [SerializeField] private float _explosionRadius = 1f;

    public bool IsBulletPiece = false;
    
    void OnCollisionEnter(Collision collision)
    {
        if (IsBulletPiece)
        {
            DestroyBullet();
            return;
        }

        Rigidbody[] bulletPiecesRb = new Rigidbody[_destroyIntoPieces];

        for (int i = 0; i < _destroyIntoPieces; i++)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * 0.8f;
            Bullet bullet = Instantiate(this, randomPos, Quaternion.identity);
            bullet.IsBulletPiece = true;
            bullet.transform.localScale *= 0.5f;
            bulletPiecesRb[i] = bullet.GetComponent<Rigidbody>();
        }

        for (int i = 0; i < bulletPiecesRb.Length; i++)
        {
            bulletPiecesRb[i].AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Destroy(gameObject);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
