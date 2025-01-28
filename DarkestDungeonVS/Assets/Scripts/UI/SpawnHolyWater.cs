using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHolyWater : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] Vector2 Spawnpoint;
    [SerializeField] GameObject text;
    [SerializeField] GameObject holyWater;
    [SerializeField] AudioSource SpawnSound;
    private Vector3 scale = new Vector3(0.75f, 0.75f,0.75f);


    public void ClickedButton()
    {
        Destroy(text);
        GameObject spawnedObject = Instantiate(prefab, Spawnpoint, Quaternion.identity);

        spawnedObject.transform.localScale = scale;

        SpawnSound.Play();

        Destroy(spawnedObject, 3f);
        Destroy(holyWater, 3f);
    }
}