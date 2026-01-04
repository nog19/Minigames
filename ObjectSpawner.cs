using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objetos;
    public float intervaloInicial = 1.5f;
    private float intervaloAtual;
    private float tempoPassado = 0f;
    public float dificuldadeIncremento = 0.05f;
    public float tempoEntreDificuldade = 10f;

    void Start()
    {
        intervaloAtual = intervaloInicial;
        InvokeRepeating("SpawnObjeto", 1f, intervaloAtual);
    }

    void Update()
    {
        tempoPassado += Time.deltaTime;

        if (tempoPassado >= tempoEntreDificuldade)
        {
            tempoPassado = 0f;
            intervaloAtual = Mathf.Max(0.3f, intervaloAtual - dificuldadeIncremento);
            CancelInvoke("SpawnObjeto");
            InvokeRepeating("SpawnObjeto", 0f, intervaloAtual);
        }
    }

    void SpawnObjeto()
    {
        int i = Random.Range(0, objetos.Length);
        float largura = 3f; // ajuste conforme a tela
        Vector3 pos = new Vector3(Random.Range(-largura, largura), transform.position.y, 0);
        GameObject obj = Instantiate(objetos[i], pos, Quaternion.identity);
        Destroy(obj, 5f); // Destroi o objeto após 5 segundos

    }
}
