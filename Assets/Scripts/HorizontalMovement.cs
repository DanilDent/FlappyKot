using UnityEngine;

public class HorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _destroyAtPositionX = -20f;

    private void Update()
    {
        if (transform.position.x < _destroyAtPositionX)
        {
            Destroy(gameObject);
            return;
        }

        transform.position += Vector3.left * GameManager.Instance.CurrentLevel.MovementSpeed * Time.deltaTime;
    }
}
