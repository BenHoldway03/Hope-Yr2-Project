using UnityEngine;

public class PlanetSpin : MonoBehaviour
{
    float _x;
    float _y;
    float _z;

    void Start()
    {
        _x = Random.Range(0, 5);
        _y = Random.Range(0, 5);
        _z = Random.Range(0, 20);
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.deltaTime;
        transform.Rotate(_x * time, _y * time, _z * time);
    }
}
