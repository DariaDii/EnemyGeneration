using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Vector3 moveDirection;
    private int _speed = 2;

    void Update()
    {
        transform.Translate(moveDirection * _speed*Time.deltaTime,Space.World);
        transform.rotation = Quaternion.LookRotation(moveDirection);
    }
}