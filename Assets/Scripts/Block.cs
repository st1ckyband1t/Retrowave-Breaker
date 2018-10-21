using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    [SerializeField] AudioClip breaksound;
    [SerializeField] float volume = 0.5f;
	private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(breaksound, Camera.main.transform.position, volume);
        Destroy(gameObject);
    }
}
