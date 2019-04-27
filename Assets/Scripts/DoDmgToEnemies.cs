using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoDmgToEnemies : MonoBehaviour
{

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log($"HIT{collision.gameObject.name}");
            collision.gameObject.GetComponent<EnemyHealth>().EnemyTakeDmg(1);
        }
    }
}
