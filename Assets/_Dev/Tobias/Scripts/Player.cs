using System;
using UnityEngine;

namespace Codergram._Dev.Tobias.Scripts
{
    public class Player : MonoBehaviour, IDamaging
    {
        [SerializeField] private float damage;
        
        public float Damage => damage;
    }
}