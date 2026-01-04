using UnityEngine;

public class VidaDoPlayer : MonoBehaviour
{
    public static VidaDoPlayer instance;
    public int vida = 3;
    public GameObject telaGameOver;

    void Awake()
    {
        instance = this;
    }

    public void PerderVida()
    {
        vida--;
        Debug.Log("Vida: " + vida);

        if (vida <= 0)
        {
            GameOver();
        }
    }

    public void GanharVida()
    {
        vida++;
        Debug.Log("Vida: " + vida);
    }

    void GameOver()
    {
        Time.timeScale = 0f;
        telaGameOver.SetActive(true);
    }
}
