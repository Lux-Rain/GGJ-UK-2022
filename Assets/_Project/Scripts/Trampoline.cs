using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField]
    private AK.Wwise.Event jumpSound;
    [SerializeField]
    private float force;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null)
        {
            jumpSound.Post(gameObject);
            if (other.transform.parent.TryGetComponent(out PlayerController player))
            {
                Debug.Log("coucou");
                player.AddJumpForce(force);
            }
        }
    }
}
