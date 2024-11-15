using System;
using System.Collections;
using UnityEngine;

public class FootstepsPlayer : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _footstepSounds;
    [SerializeField]
    private float _interval = 0.5f;

    private Coroutine _playCoroutine;
    private bool _isPlaying;

    private AudioClip FootstepSound => _footstepSounds[UnityEngine.Random.Range(0, _footstepSounds.Length)];

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_rigidbody == null)
        {
            return;
        }

        if (_rigidbody.velocity.magnitude > 0.1f && !_isPlaying)
        {
            Play();
        }
        else if (_rigidbody.velocity.magnitude <= 0.1f && _isPlaying)
        {
            Stop();
        }
    }

    public void Play()
    {
        Stop();
        if (_playCoroutine == null)
        {
            _isPlaying = true;
            _playCoroutine = StartCoroutine(PlayFootsteps());
        }
    }

    public void Stop()
    {
        if (_playCoroutine != null)
        {
            _isPlaying = false;
            StopCoroutine(_playCoroutine);
            _playCoroutine = null;
        }
    }

    private IEnumerator PlayFootsteps()
    {
        while (true)
        {
            AudioSource.PlayClipAtPoint(FootstepSound, transform.position, Config.AudioVolume);
            yield return new WaitForSeconds(_interval);
        }
    }
}
