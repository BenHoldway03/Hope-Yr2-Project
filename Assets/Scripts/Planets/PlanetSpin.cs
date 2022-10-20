using UnityEngine;

public class PlanetSpin : MonoBehaviour
{
    //Spins the Planets at a random axis and speed.

    float _x;
    float _y;
    float _z;

    //Randomises x, y, and z float variables at start of runtime
    void Start()
    {
        _x = Random.Range(0, 5);
        _y = Random.Range(0, 5);
        _z = Random.Range(0, 20);
    }

    //Rotates the planet at the different randomised variables set before
    void Update()
    {
        float time = Time.deltaTime;
        transform.Rotate(_x * time, _y * time, _z * time);
    }
}
