using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class Enemy : MonoBehaviour, IScoreProvider
    {

        public Light directionalLight;

        // Cu�ntas vidas tiene el enemigo
        [SerializeField]
        private int hitPoints;

        private Animator animator;
        private AudioSource audioSource;

        public event IScoreProvider.ScoreAddedHandler OnScoreAdded;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            if (hitPoints < 0)
            {
                StartCoroutine(Die());
            }
        }
        // M�todo que se llamar� cuando el enemigo reciba un impacto
        public void Hit()
        {
            Debug.Log(gameObject.name + hitPoints);
            animator.SetBool("Hit", true);
            audioSource.Play();
            hitPoints--;
        }

        private IEnumerator Die()
        {
            animator.SetBool("Die", true);
            directionalLight.GetComponent<Light>().enabled = true;
            yield return new WaitForSeconds(3f);
            directionalLight.GetComponent<Light>().enabled = false;
            Destroy(gameObject);
        }
    }

}