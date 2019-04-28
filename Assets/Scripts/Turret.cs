using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public string EnemyTag;
    public GameObject GunBarrel;
    public GameObject Bullet;
    public float bulletSpeed;

    public int Dmg;
    /// <summary>
    /// The gun will shoot every X amoun of sec
    /// </summary>
    public float ShootEvery; // Eks 5 shots every sec 5/sec

    public GameObject primaryTarget;

    private float fireTimer;

    //  private Vector3 m_lastKnownPosition = Vector3.zero;
    private Quaternion lookAtRotation;

    public AudioClip audioClip;
    private AudioSource audioSource;



    void Start()
    {
        fireTimer = Random.Range(0f, 4f); ;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }


    void Update()
    {
        TrackTarget();
        ShootTarget();
    }

    private void TrackTarget()
    {
        if (primaryTarget != null)
        {
            Vector3 relativePos = primaryTarget.transform.position - GunBarrel.transform.position;
            var rotZ = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            lookAtRotation = Quaternion.Euler(0, 0, rotZ);
            GunBarrel.transform.rotation = lookAtRotation;
        }
        else
        {
            Debug.LogError("Cant Find Player");
        }
    }

    void ShootTarget()
    {
        if (!primaryTarget)
        {
            return;
        }
        else
        {
            fireTimer += Time.deltaTime;

            if (fireTimer >= ShootEvery)
            {
                var pos = new Vector3(GunBarrel.transform.position.x, GunBarrel.transform.position.y, 0);
                var bulletClone = Instantiate(Bullet, pos, lookAtRotation);
                var bullet = bulletClone.GetComponent<TurretBullet>();
                bullet.MyTurret = this;
                bullet.FireProjectile(GunBarrel, primaryTarget, Dmg, bulletSpeed);

                audioSource.pitch = Random.Range(.75f, 1.25f);
                audioSource.Play();

                fireTimer = 0.0f;
            }
        }
    }
}
