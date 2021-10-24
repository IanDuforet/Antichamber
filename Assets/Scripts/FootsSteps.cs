using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootsSteps : MonoBehaviour
{
    // Use this for initialization
    public CharacterController _character;
    public float _maxCooldown = 0.3f;
    private float _cooldown;

    void Start()
    {
        _cooldown = _maxCooldown;

    }

    // Update is called once per frame
    void Update()
    {
        if (_character.isGrounded == true && _character.velocity.magnitude > 2f && GetComponent<AudioSource>().isPlaying == false)
        {
            _cooldown -= Time.deltaTime;
            if(_cooldown <= 0)
            {
                GetComponent<AudioSource>().Play();
                _cooldown = _maxCooldown;
            }

        }
    }
}
