using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
        private void OnEnable()=> SpotlightScript.OnPlayerDetect += spawnEnemy;
    private void OnDisable()=> SpotlightScript.OnPlayerDetect -= spawnEnemy;
    public GameObject enemyPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation); 
    }
}
