using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breaksound;
    [SerializeField] float volume = 0.5f;

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
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position, volume);
        Destroy(gameObject);
        level.BlockDestroyed();
        score.AddScore();
    }
}
