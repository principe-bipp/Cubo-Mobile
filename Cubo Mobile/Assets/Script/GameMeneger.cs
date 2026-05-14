using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameMeneger : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    private float spawnInterval = 2f;
    public bool isGameOver = false;
    public float spawnY = 11f;
    public float spawnX = 7f;

    [SerializeField] private InputActionReference cancelAction;

    private void OnEnable()
    {
        cancelAction.action.performed += OnCancel;
    }

    private void OnDisable()
    {
        cancelAction.action.performed -= OnCancel;

        cancelAction.action.Disable();
    }

    private void OnCancel(InputAction.CallbackContext context)
    {
        Debug.Log("ESC apertado");
    }

    private void Start()
    {
        StartCoroutine(SpawnObstacle());
    }

    

    private IEnumerator SpawnObstacle()
    {
        while (!isGameOver)
        {

        }

            var obstacleSpawn = Random.Range(1, 4);
        for(int i = 0; i< obstacleSpawn; i++)
        {
            var xPosition = Random.Range(-spawnX, spawnX);

            var damping = Random.Range(0f, 2f);

                var objObstacle =
                    Instantiate(obstaclePrefab,
                    new Vector3(xPosition, spawnY, 0), Quaternion.identity);

                objObstacle.GetComponent<Rigidbody>().linearDamping = damping;
        }

        {
            var xPosition = Random.Range(-spawnX, spawnX);

            Instantiate(obstaclePrefab,
                new Vector3(xPosition, spawnY, 0), Quaternion.identity);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

   private IEnumerator ScaleTime(float start, float end, float duration)
    {
        float lasTime = Time.realtimeSinceStartup;
        float timer = 0.0f;

        while (timer < duration)
        {
            //Interpolacão e Suavisação do tempo
            Time.timeScale = Mathf.Lerp(start, end, timer / duration);

            //Ajustar e Manter a conciencia do tempo de fisica
            Time.fixedDeltaTime = 0.02f * Time.timeScale;

            timer += Time.realtimeSinceStartup - lasTime;
            lasTime = Time.realtimeSinceStartup;

            yield return null;
        }
        Time.timeScale = end;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }


}
