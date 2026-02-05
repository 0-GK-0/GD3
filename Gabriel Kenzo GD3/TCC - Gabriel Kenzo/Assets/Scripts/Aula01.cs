using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aula01 : MonoBehaviour
{
    //Variáveis
    string nome_jogador = "GK";

    // Tipos  de variáveis
    bool esta_vivo = true; //V | F
    int vida_player = 3; //Números Inteiros
    float velocidade = 8f; //Números Decimais
    string categoria = "Guerreiro"; //Texto

    bool tem_chave = false;
    float tempo_recarga = .3f;
    int nivel = 0;
    string personagem = "Irineu";

    Vector3 posInicial = new Vector3(0f, 0f, 0f); //Armazena três valores do tipo float
    Color corJogador = Color.red;

    int[] dano_armas = { 10, 20, 30, 40 }; //Armazena diversos valores em uma variável de tamanho fixo
    string[] inventario = { "Espada", "Poção", "Chave" };

    const int data_nascimento = 2010; //Constante é uma variável que nunca pode ter o seu valor alterado
    enum EstadoJogador{
        Normal,
        Envenenado,
        Atordoado
    } //Uma lista com os possíveis valores dessa variável

    EstadoJogador estadoAtual = EstadoJogador.Normal; //EstadoJogador se torna um novo tipo de variável

    //=================== Variáveis ===================//

    void Start()
    {
        Debug.Log("Nome: " + nome_jogador);
        Debug.Log("Está Vivo: " + esta_vivo);
        Debug.Log("Vida: " + vida_player);
        Debug.Log("Velocidade: " + velocidade);
        Debug.Log("Categoria: " + categoria);
        Debug.Log("Tem Chave: " + tem_chave);
        Debug.Log("Tempo de Recarga: " + tempo_recarga);
        Debug.Log("Nível: " + nivel);
        Debug.Log("Personagem: " + personagem);
        Debug.Log("Posição Inicial: " + posInicial);
        Debug.Log("Cor do Jogador: " + corJogador);
        Debug.Log("Dano das Armas: " + dano_armas);
        Debug.Log("Inventário: " + inventario);
        Debug.Log("Data de Nascimento: " + data_nascimento);
        Debug.Log("Estado Atual: " + estadoAtual);

        VerificarVida();
    }

    //=================== Função ===================//
    void VerificarVida()
    {
        if (vida_player <= 0)
        {
            esta_vivo = false;
            Debug.Log("Jogador Morreu");
        }
    }
}
