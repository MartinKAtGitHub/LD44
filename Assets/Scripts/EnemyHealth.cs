using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int HP = 1;

    public SpriteRenderer spriteRenderer;
    public List<GameObject> activeEnemies;

    public AudioClip DeathSound;

    public GameObject DeathSoundOBJ;


    public void EnemyTakeDmg(int dmg)
    {
        HP -= dmg;
        if (HP <= 0)
        {
            // play death anim
            //if(audioSource.clip != null)
            //{
            //    audioSource.clip = DeathSound;
            //    audioSource.Play();
            //}
            activeEnemies.Remove(this.gameObject);

            if (DeathSoundOBJ != null)
            {
                var source = Instantiate(DeathSoundOBJ, transform.position, Quaternion.identity);
                source.GetComponent<EnemyDeathSound>().AudioClip = DeathSound;
                Debug.Log("DEATH SPAWN SOUND");
            }

            Destroy(this.gameObject);

        }
    }
}
