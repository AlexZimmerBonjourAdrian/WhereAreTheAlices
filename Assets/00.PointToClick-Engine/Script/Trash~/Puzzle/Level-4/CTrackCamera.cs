using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CTrackCamera : MonoBehaviour
{
    private Transform Player;
    [SerializeField] private Vector2 offset; // Offset de la cámara respecto al jugador
    [SerializeField] private float smoothSpeed = 0.125f; // Velocidad del Lerp

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").transform;
        
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (Player != null)
        {
            // Calcula la posición objetivo de la cámara con el offset
          Vector3 desiredPosition = new Vector3(Player.position.x,0f,transform.position.z);

            // Usa Lerp para mover la cámara suavemente hacia la posición objetivo
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Actualiza la posición de la cámara
            transform.position = smoothedPosition;
        }
    }
}