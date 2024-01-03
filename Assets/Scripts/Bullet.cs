using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	private Transform target;
    public float speed = 70f;
    public GameObject impactFX;

	void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 direction = target.position - transform.position;
        float distanceFPS = speed * Time.deltaTime;

        if (direction.magnitude <= distanceFPS)
        {
            Hit();
            return;
        }

        transform.Translate(direction.normalized * distanceFPS, Space.World);
    }


	public void Seek(Transform _target)
    {
        target = _target;
    }
	
    void Hit()
    {
        GameObject effect = (GameObject)Instantiate(impactFX, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
