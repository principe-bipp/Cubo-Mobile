using UnityEngine;

public class AutoDestroi : MonoBehaviour
{
    public float delay = 2.5f;

    public void destroyObject()
    {
        Destroy(gameObject, delay);
    }

    private void Start()
    {
        destroyObject();
    }
}
