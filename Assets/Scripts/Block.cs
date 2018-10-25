using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {


    //config params
    [SerializeField] AudioClip breaksound;
    [SerializeField] float volume = 0.5f;
    [SerializeField] GameObject particleEffectVFX;
    [SerializeField] Sprite[] hitSprites;

    //cached reference
    Level level;
    GameSession score;

    //states
    [SerializeField] int timesHit; //serialized just for debugging purposes

    private void Start()
    {
        score = FindObjectOfType<GameSession>();
        CountBreakableBlocks();
    }

    private void CountBreakableBlocks()
    {
        level = FindObjectOfType<Level>();
        if (tag == "BreakableTile")
        {
            level.CountBlocks();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyIfBreakable();
        ParticleVFX();
        PlayImpactAudio();
    }

    private void DestroyIfBreakable()
    {
        if (tag == "BreakableTile")
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        ++timesHit;
        int maxHits = hitSprites.Length  + 1;
        if (timesHit >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextDamagedSprite();
        }
    }

    private void ShowNextDamagedSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex] != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Sprite Missing from array of " + gameObject.name);
        }
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        level.BlockDestroyed();
        score.AddScore();
    }

    private void PlayImpactAudio()
    {
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position, volume);
    }

    private void ParticleVFX()
    {
        GameObject impact = Instantiate(particleEffectVFX, transform.position, transform.rotation);
        Destroy(impact, 1f);
    }
}
