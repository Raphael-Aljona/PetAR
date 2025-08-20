using System;
using UnityEngine;

public class SeguirAlimento : MonoBehaviour
{
    public string tagAlvo = "Alimento"; // Tag do objeto a ser seguido
    public float velocidade = 5f;       // Velocidade de movimento
    public float rotacaoVel = 5f;       // Velocidade de rota��o
    public float distanciaMinima = -1f;  // Dist�ncia m�nima do alvo

    private Transform alvo;

    void Update()
    {
        // Se n�o tem alvo, tenta encontrar um com a tag
        if (alvo == null)
        {
            GameObject alvoObj = GameObject.FindWithTag(tagAlvo);
            if (alvoObj != null)
            {
                alvo = alvoObj.transform;
            }
            return; // enquanto n�o tem alimento, n�o faz nada
        }

        // Posi��o alvo apenas no plano XZ (mant�m Y da raposa)
        Vector3 posAlvo = new Vector3(alvo.position.x, alvo.position.y, alvo.position.z);

        // Dist�ncia no plano XZ
        float distancia = Vector3.Distance(transform.position, posAlvo);

        // Movimento suave no XZ
        if (distancia > distanciaMinima)
        {
            Vector3 novaPos = Vector3.Lerp(transform.position, posAlvo, velocidade * Time.deltaTime / distancia);
            transform.position = novaPos;
        }

        // Rota��o suave apenas no eixo Y
        Vector3 direcao = (posAlvo - transform.position).normalized;
        if (direcao != Vector3.zero)
        {
            Quaternion rotacaoAlvo = Quaternion.LookRotation(direcao, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAlvo, rotacaoVel * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Alimento"))
        {
            Destroy(other.gameObject);
            alvo = null;
        }
    }
}
