using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Archer
{

    public class CameraController : MonoBehaviour
    {

        // El objeto al que va a seguir la c�mara
        [SerializeField]
        private Transform target;

        // �ngulo de la c�mara
        [SerializeField]
        private float angle;

        // Distancia a la que se coloca la c�mara con respecto a la arquera
        [SerializeField]
        private float distance;

        // Desplazamiento con respecto al pivote de la arquera 
        // (para que la c�mara est� m�s orienta hacia la cabeza que a los pies)
        [SerializeField]
        private Vector3 offset;
        
        // Velocidad a la que se mueve la c�mara con Vector3.MoveTowards()
        //[SerializeField]
        //private float travelSpeed;

        // Tiempo que tarda la c�mara en moverse a la nueva ubicaci�n con Vector3.Lerp()
        [SerializeField]
        private float travelTime;

        private void Update()
        {
            Vector3 desiredPosition = target.transform.position + (Quaternion.Euler(0, angle, 0) * offset) - (target.forward * distance);
            transform.position = Vector3.Lerp(transform.position, desiredPosition,travelTime / Time.deltaTime);
            transform.LookAt(target.position + offset);
        }

    }

}
