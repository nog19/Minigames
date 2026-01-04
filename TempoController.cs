using UnityEngine;
using UnityEngine.UI;

public class TempoController : MonoBehaviour
{
    public Text tempoTexto;
    private float tempo;

    void Update()
    {
        tempo += Time.deltaTime;
        tempoTexto.text = Mathf.FloorToInt(tempo).ToString() + "s";
    }
}
