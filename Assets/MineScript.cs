using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Codergram
{
    public class MineScript : MonoBehaviour
    {
        
        public GameObject explosionPrefab;
        
        private BoxCollider mineCollider;
        
        // Start is called before the first frame update
        void Start()
        {
            mineCollider = GetComponentInChildren<BoxCollider>();

        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        void Explode()
        {
            float _radius = 5.0F;
            float _power = 10.0F;
            
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, _radius);
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();

                if (rb != null)
                    rb.AddExplosionForce(_power, explosionPos, _radius, 3.0F);
            }

            foreach (ParticleSystem ps in explosionPrefab.GetComponentsInChildren<ParticleSystem>())
            {
                ps.Play();
                Destroy(gameObject, ps.main.duration);
            }

            Debug.Log("The things go boom");
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Explode();
        }
    }
}
