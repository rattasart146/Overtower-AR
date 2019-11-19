using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTowerObject : MonoBehaviour
{
    [SerializeField]
    private GameObject _cubePrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnRoutine()
    {
        int defaultBlock = 18;
        float spwX = 0f;
        float spwY = 0.4f;
        Vector3 posToSpawn = new Vector3(0, 0, 0);
        Quaternion rotation = Quaternion.Euler(0, 0, 0);

        //Loop for Spawn Block 18th Floors
        while (defaultBlock > 0)
        {
            int row = 3;
            
            //Loop for Spawn Block 3 piece/row
            while (row > 0)
            {
                //Check Even/Odd for Rotate Block
                if ((defaultBlock % 2) == 0)
                {
                    rotation = Quaternion.Euler(0, 90, 0);
                    spwX = 1;
                    if (row == 3)
                    {
                        posToSpawn = new Vector3(Random.Range(spwX, spwX + 0.1f), spwY, Random.Range(0.9f, 1.1f));
                    }
                    else if (row == 2)
                    {
                        posToSpawn = new Vector3(Random.Range(spwX, spwX + 0.1f), spwY, Random.Range(0.1f, -0.1f));
                    }
                    else if (row == 1)
                    {
                        posToSpawn = new Vector3(Random.Range(spwX, spwX + 0.1f), spwY, Random.Range(-0.9f, -1.1f));
                    }
                }
                else
                {
                    posToSpawn = new Vector3(Random.Range(spwX, spwX + 0.1f), spwY, Random.Range(0.1f, -0.1f));
                    rotation = Quaternion.Euler(0, 0, 0);
                }

                //Spawn!!!!
                Instantiate(_cubePrefab, posToSpawn, rotation);
                yield return new WaitForSeconds(0.01f);
                spwX += 1.02f;
                row--;
            }
            
            spwY += 0.8f;
            spwX = Random.Range(0f, 0.05f);
            defaultBlock--;
        }
    }
}
