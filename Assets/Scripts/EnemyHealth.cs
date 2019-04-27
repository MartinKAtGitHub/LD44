using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int HP = 1;
    
 
    public void EnemyTakeDmg( int dmg)
    {
        HP -=  dmg;
        if(HP <= 0)
        {
            // play death anim
            Destroy(this.gameObject);
        
        }
    }
}
