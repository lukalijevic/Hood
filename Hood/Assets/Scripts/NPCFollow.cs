using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour {

    private GameObject _player;
    public float Speed = 3.0f;
    private NPCAttack _npcAttack;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _npcAttack = transform.GetComponentInParent<NPCAttack>();
    }

    private void Update()
    {
        if (_npcAttack.ShouldFollow)
        {
            transform.LookAt(_player.transform);
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
    }
}
