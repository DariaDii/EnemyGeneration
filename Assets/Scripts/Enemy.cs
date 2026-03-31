using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _moveDirection;
    private int _speed = 2;

    private void Update()
    {
        transform.Translate(_moveDirection * _speed*Time.deltaTime,Space.World);
        transform.rotation = Quaternion.LookRotation(_moveDirection);
    }

    public void ChangeMoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
    }
}