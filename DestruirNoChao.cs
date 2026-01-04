using UnityEngine;

public class DestruirNoChao : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D colisao)
    {
        if (colisao.gameObject.CompareTag("chao"))
        {
            Destroy(gameObject);
        }
    }
}
