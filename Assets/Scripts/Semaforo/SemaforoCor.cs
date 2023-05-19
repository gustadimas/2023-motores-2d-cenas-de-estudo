using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SemaforoCor : MonoBehaviour
{
    [SerializeField] GameObject Cor1, Cor2, Cor3;

    bool cor1 = false;
    bool cor2 = false;
    bool cor3 = false;

    private void Start()
    {
        Cor3.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);
        Cor2.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);
        Cor1.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);

        StartCoroutine("WaitAndDebug");
    }

    private void Update()
    {

    }

    IEnumerator WaitAndDebug()
    {
        yield return new WaitForSeconds(2f);
        Cor1.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.green);
        Cor2.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);
        Cor3.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);

        yield return new WaitForSeconds(2f);
        Cor2.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.yellow);
        Cor3.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);
        Cor1.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);

        yield return new WaitForSeconds(5f);
        Cor3.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.red);
        Cor2.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);
        Cor1.gameObject.GetComponent<SpriteRenderer>().material.SetColor("_Color", Color.gray);

        StartCoroutine("WaitAndDebug");
    }
}
