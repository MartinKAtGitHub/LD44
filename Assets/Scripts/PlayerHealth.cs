using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int playerHealth;
    [SerializeField]
    private float IframeTime = 3;

    private float IframeTimer;
    private bool Iframes =false;

    private bool flash = true;
    private void Start()
    {
        IframeTimer = IframeTime;
    }
    private void Update()
    {
        if (Iframes)
        {
            IframeTimer -= Time.deltaTime;
            if (IframeTimer <= 0)
            {
                IframeTimer = IframeTime;
                CancelInvoke();
                Iframes = false;
            }
        }
    }

    public void PlayerDmgOnAttack(int dmg)
    {
        playerHealth -= dmg;
        Debug.Log("Player DMG" + playerHealth);

        if (playerHealth <= 0)
        {
            // play death anim
            Destroy(this.gameObject);
        }
    }

    public void PlayerTakeDmg(int dmg)
    {
        if (!Iframes)
        {
            playerHealth -= dmg;
            Debug.Log("Player DMG" + playerHealth);

            if (playerHealth <= 0)
            {
                // play death anim
                Destroy(this.gameObject);
            }

            InvokeRepeating("PlayerIframes", 0, 0.1f);
            Iframes = true;
        }
        else
        {
            Debug.Log("Player has I frames");
        }

    }

    private void PlayerIframes()
    {
            flash = !flash;
            spriteRenderer.enabled = flash;
    }


}
