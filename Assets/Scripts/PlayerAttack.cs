using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private EightDirectionMovement directionMovement;
    [SerializeField]
    private PlayerHealth playerHealth;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponentInChildren<Animator>();
        directionMovement =  GetComponentInChildren<EightDirectionMovement>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("ATTACK");
            playerAnimator.SetTrigger("Attack");
            playerHealth.PlayerDmgOnAttack(1);
        }

    }
}
