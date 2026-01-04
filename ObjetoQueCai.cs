using UnityEngine;

public class ObjetoQueCai : MonoBehaviour
{
    public bool eVida;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (eVida)
                VidaDoPlayer.instance.GanharVida();
            else
                VidaDoPlayer.instance.PerderVida();

            Destroy(gameObject);
        }
    }
}
