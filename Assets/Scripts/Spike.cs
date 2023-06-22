using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private Sprite spikeInSprite;
    [SerializeField] private Sprite spikeOutSprite;

    private float spriteInTimer = 5f;
    private float spriteOutTimer = 2f;
    private float timer;

    private SpriteRenderer spriteRender;

    private bool damageGiven = false;

    public LayerMask essences;

    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        timer = spriteInTimer + spriteOutTimer;
    }

    private void FixedUpdate()
    {
        Animation();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GiveDamage(collision);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GiveDamage(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        damageGiven = false;
    }

    private void Animation()
    {
        timer -= Time.deltaTime;

        if (timer <= spriteOutTimer) 
            spriteRender.sprite = spikeOutSprite;

        else if (timer > spriteOutTimer)
        {
            spriteRender.sprite = spikeInSprite;
            damageGiven = false;
        }

        if (timer < 0) 
            timer = spriteInTimer + spriteOutTimer;
    }

    private void GiveDamage(Collider2D collision)
    {
        if (spriteRender.sprite == spikeInSprite || damageGiven) return;

        if(collision.gameObject.tag == "Player")
        {
            var trg = collision.gameObject.GetComponent<Player>();
            trg.TakeDamage(10);
        }

        if(collision.gameObject.tag == "Enemy")
        {
            var trg = collision.gameObject.GetComponent<Enemy>();
            trg.TakeDamage(2);
        }
    }
}
