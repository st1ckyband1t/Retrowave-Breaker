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
        level = FindObjectOfType<Level>();
        score = FindObjectOfType<GameSession>();
        level.CountBreakableBlocks();
    }

	private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }

    private void DestroyBlock()
    {
        PlayImpactAudio();
        Destroy(gameObject);
        ParticleVFX();
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
