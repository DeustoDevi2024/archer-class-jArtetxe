using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        // Cuántas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        public Light directionalLight;

        private Animator animator;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (hitPoints < 0)
            {
                StartCoroutine(Die());
            }
        }
        // Método que se llamará cuando el enemigo reciba un impacto
        public void Hit()
        {
            Debug.Log(gameObject.name + hitPoints);
            animator.SetBool("Hit", true);
            hitPoints--;
        }

        private IEnumerator Die()
        {
            animator.SetBool("Die", true);
            directionalLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(3f);
            directionalLight.enabled = false;
            Destroy(gameObject);
        }
    }

}