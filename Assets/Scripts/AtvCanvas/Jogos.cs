using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Jogos : MonoBehaviour
{
    [SerializeField] GameObject contilhama;
    [SerializeField] GameObject asAventurasDeElisa;
    [SerializeField] GameObject dino;
    [SerializeField] GameObject nenhumJogo;

    private void Update()
    {
        RaycastJogos();
    }

    public void RaycastJogos()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {
                if (contilhama == true)
                {
                    nenhumJogo.SetActive(false);
                }
                
                if (asAventurasDeElisa == true)
                {
                    nenhumJogo.SetActive(false);
                }
                                
                if (dino == true)
                {
                    nenhumJogo.SetActive(false);
                }


                print(hit.collider.gameObject.name);

                if (hit.collider.gameObject.name == "Contilhama")
                {
                    contilhama.SetActive(true);

                    Invoke("ContilhamaJogo", 1f);
                }

                if (hit.collider.gameObject.name == "As Aventuras de Elisa")
                {
                    asAventurasDeElisa.SetActive(true);

                    Invoke("AsAventurasDeElisaJogo", 1f);
                }

                if (hit.collider.gameObject.name == "Dino")
                {
                    dino.SetActive(true);
                    Invoke("DinoJogo", 1f);
                }
            } 
            
            if (hit.collider == null)
            {
                nenhumJogo.SetActive(true);
            }
        }
    }

    public void ContilhamaJogo()
    {
        contilhama.SetActive(false);
    }    
    
    public void AsAventurasDeElisaJogo()
    {
        asAventurasDeElisa.SetActive(false);
    }    
    
    public void DinoJogo()
    {
        dino.SetActive(false);
    }
}
