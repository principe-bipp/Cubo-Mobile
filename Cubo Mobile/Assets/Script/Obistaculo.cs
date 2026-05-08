using UnityEngine;

public class Obistaculo : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obistaculo"))
        {
          Destroy(gameObject);
        }
        
    }

}
