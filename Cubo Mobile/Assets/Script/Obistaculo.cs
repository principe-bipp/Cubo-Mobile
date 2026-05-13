using UnityEngine;

public class Obistaculo : MonoBehaviour
{
    private Vector3 rotation;
    public ParticleSystem destructionParticle;//particula destruicao de particula

    private void Start()
    {
        var xRotation = Random.Range(0.5f, 1f);
        rotation = new Vector3(xRotation, 0);
    }

    private void Update()
    {
        transform.Rotate(rotation);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Obistaculo"))
        {
           Instantiate(destructionParticle, transform.position, Quaternion.identity);
          Destroy(gameObject);
        }
        
    }

}
