using UnityEngine;
using TMPro;

public class Cronometro : MonoBehaviour
{
    public TextMeshProUGUI textoTempo;
    private float tempo;
    private bool ativo = true;

    void Update()
    {
        if (!ativo) return;

        tempo += Time.deltaTime;
        textoTempo.text = "Tempo: " + tempo.ToString("F1") + "s";
    }

    public void PararCronometro()
    {
        ativo = false;
    }
}
