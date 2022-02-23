using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWhenCollide : MonoBehaviour
{
    public GameObject objectPrefab;
    public string sceneToChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            if (sceneToChange != "")
            {
                SceneManager.LoadScene(sceneToChange);
            }

            Quaternion q = objectPrefab.transform.rotation;
            //float x = Random.Range(0 - spawnRangeX, spawnRangeX);
            //float y = Random.Range(0 - spawnRangeY, spawnRangeY);
            // Return the coordinates as a vector
            Vector3 location = new Vector3(transform.position.x + 4, transform.position.y, 0);

            GameObject newGameObject = Instantiate(objectPrefab, location, q, null);
        }
    }
}
