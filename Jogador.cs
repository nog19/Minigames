using UnityEngine;
using UnityEngine.SceneManagement;

public class Jogador : MonoBehaviour
{
    private Cronometro cronometro;

    public float velocidade = 5f;
    private Vector2 direcao = Vector2.right;

    public int vidas = 3;
    public GameObject painelGameOver;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cronometro = FindObjectOfType<Cronometro>();

    }

    void Update()
    {
        rb.velocity = direcao * velocidade;

        // Inverter direção ao clicar na tela
        if (Input.GetMouseButtonDown(0))
        {
            direcao *= -1;
        }
    }

    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("Wall"))
        {
            direcao *= -1;
        }

        if (colisao.gameObject.CompareTag("Dano"))
        {
            vidas--;
            Destroy(colisao.gameObject);

            if (vidas <= 0)
            {
                GameOver();
            }
        }

        if (colisao.gameObject.CompareTag("Vida"))
        {
            vidas++;
            Destroy(colisao.gameObject);
        }
    }

    void GameOver()
    {
        cronometro.PararCronometro();
        Time.timeScale = 0f;
        painelGameOver.SetActive(true);
    }

    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
