using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public float damage;
    public float bulletSpeed;
    public float range;

    private Vector3 startPos;
    private Rigidbody rb;

    public void SetStats(float _damage, float _bulletspeed, float _range)
    {
        damage = _damage;
        bulletSpeed = _bulletspeed;
        range = _range;
    }

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        CheckRange();
        MoveBullet(bulletSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealthManager>().DamageEnemy(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //private void FixedUpdate()
    //{
    //    MoveBullet(bulletSpeed);
    //}
    private void CheckRange()
    {
        if(Vector3.Distance(startPos,transform.position) >= range )
        {
            Destroy(gameObject);
        }
    }
    private void MoveBullet(float _speed)
    {
        //rb.velocity = Vector3.forward * _speed;
        transform.Translate(Vector3.forward * (_speed * Time.deltaTime));
    }
}
