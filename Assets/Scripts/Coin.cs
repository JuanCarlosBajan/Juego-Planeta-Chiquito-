using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public LevelManager manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(0, Mathf.Sin(Time.time) * Time.deltaTime, 0);
        transform.Rotate(0, 30 * Time.deltaTime, 0);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Object a = other;
        manager.addCoins();
        Destroy(this.gameObject);
    }
}
