using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour {

    /// <summary>
    /// How far the bullet can go before self distruction;
    /// </summary>
    public float MaxBulletTravelDistance;
    public GameObject Target;
    public Turret MyTurret;

    private int dmg;
    private float bulletSpeed;

    Vector3 bulletDirection;

	// Update is called once per frame
	void Update ()
    {
        transform.position += bulletDirection * (bulletSpeed * Time.deltaTime);
	}

    public void FireProjectile(GameObject launcher, GameObject target, int damage, float bulletSpeed)
    {
        if (launcher && target)
        {
            bulletDirection = (target.transform.position - launcher.transform.position).normalized;
            Target = target;
            dmg = damage;
            this.bulletSpeed = bulletSpeed;
            // Destroy(gameObject, 10.0f);
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
     {
        if (collision.gameObject.tag == Target.gameObject.tag)
        {
            Debug.Log("BULLET HIT PLAYER");
            collision.gameObject.GetComponent<PlayerHealth>().PlayerTakeDmg(dmg);
            Destroy(this.gameObject);
        }

       if(collision.gameObject.tag == "Wall")
        {
            Debug.Log("BULLET HIT WALL");
            Destroy(this.gameObject);
        }
    }
}
