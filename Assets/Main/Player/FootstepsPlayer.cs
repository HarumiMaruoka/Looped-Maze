using System;
using System.Collections;
using UnityEngine;

public class FootstepsPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _footstepSounds;
    [SerializeField]
    private float _interval = 0.5f;

    private float _intervalTimer;

    private AudioClip FootstepSound => _footstepSounds[UnityEngine.Random.Range(0, _footstepSounds.Length)];

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _intervalTimer = _interval;
    }

    private void Update()
    {
        if (_rigidbody == null)
        {
            return;
        }

        if (_intervalTimer > 0)
        {
            _intervalTimer -= Time.deltaTime;
        }

        if (_rigidbody.velocity.magnitude > 0.1f && _intervalTimer <= 0f)
        {
            Play();
            _intervalTimer = _interval;
        }
    }

    public void Play()
    {
        AudioSource.PlayClipAtPoint(FootstepSound, transform.position, Config.AudioVolume);
    }
}
