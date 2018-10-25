using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breaksound;
    [SerializeField] float volume = 0.5f;
    [SerializeField] GameObject particleEffectVFX;

    //cached reference
    Level level;
    GameSession score;

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
            DestroyBlock();
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
