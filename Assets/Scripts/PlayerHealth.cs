using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private PlayerAttack playerAttack;
    private EightDirectionMovement directionMovement;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private int maxHealth;
    public int currentHealth;

    [SerializeField]
    private float IframeTime = 3;

    private float IframeTimer;
    private bool Iframes = false;

    private bool flash = true;
    public List<GameObject> activeEnemeis;

    [SerializeField]
    AudioClip onHit;
    [SerializeField]
    AudioClip onDeath;

    private AudioSource audioSource;
    private bool isAlive;
    public GameObject waveCountPnl;

    public Text text;
    public GameObject GameOverPnl;
    public GameObject JokePnl;

    public int Wavecount;

    public int MaxHealth
    { get
        {
            return maxHealth;
        }
        set
        {
            maxHealth = value;

        }
    }

    private void Start()
    {

        currentHealth = MaxHealth;
        text.text = currentHealth.ToString();

        isAlive = true;

        IframeTimer = IframeTime;
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }
        playerAttack = GetComponent<PlayerAttack>();
        directionMovement = GetComponent<EightDirectionMovement>();
        audioSource = GetComponent<AudioSource>();
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
        if(isAlive)
        {
            currentHealth -= dmg;
           // audioSource.clip = onHit;
           // audioSource.Play();
            text.text = currentHealth.ToString();

            if (currentHealth <= 0)
            {
                DEATH();
            }
        }
    }

    public void PlayerTakeDmg(int dmg)
    {
        if(isAlive)
        {
            if (!Iframes)
            {
                currentHealth -= dmg;
                audioSource.clip = onHit;
                audioSource.Play();
                text.text = currentHealth.ToString();

                if (currentHealth <= 0)
                {

                    DEATH();

                    //Destroy(this.gameObject);
                }

                InvokeRepeating("PlayerIframes", 0, 0.1f);
                Iframes = true;
            }
        }
    }

    private void PlayerIframes()
    {
        flash = !flash;
        spriteRenderer.enabled = flash;
    }


    public void ResetHP()
    {
        currentHealth = MaxHealth;
        text.text = currentHealth.ToString();
    }

    void DEATH()
    {
        if(Wavecount <= 5)
        {
            JokePnl.SetActive(true);
        }


        waveCountPnl.SetActive(true);
        isAlive = false;

        GameOverPnl.SetActive(true);

        audioSource.clip = onDeath;
        audioSource.Play();

        directionMovement.Ondeath();
        directionMovement.enabled = false;
        playerAttack.enabled = false;

        CancelInvoke();
        enabled = false;
    }
}
