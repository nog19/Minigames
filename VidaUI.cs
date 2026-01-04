using UnityEngine;
using TMPro;

public class VidaUI : MonoBehaviour
{
    public TextMeshProUGUI textoVidas;
    public Jogador jogador;

    void Update()
    {
        if (jogador != null)
        {
            textoVidas.text = "Vidas: " + jogador.vidas;
        }
    }
}
