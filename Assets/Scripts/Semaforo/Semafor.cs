using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Semafor : MonoBehaviour
{
    IEnumerator coroutine;

    private void Start()
    {
        Debug.Log("Iniciando " + Time.time + " segundos");
        coroutine = WaitAndDebug(2.0f);
        StartCoroutine(coroutine);
        Debug.Log("Coroutine Iniciada");
    }

    IEnumerator WaitAndDebug(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Coroutine Finalizada: " + Time.time + " seconds");
    }
}
