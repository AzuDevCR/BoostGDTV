using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [Range(0,1)]float movementFactor;
    [SerializeField][Range(0.1f,10f)] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        const float tau = Mathf.PI * 2;//Constant 6.283
        float cycles = Time.time / period; //Grows continuosly
        float rawSinWave = Mathf.Sin(cycles * tau); //-1 to 1
        movementFactor = (rawSinWave + 1f) / 2f; // Recalculation from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
