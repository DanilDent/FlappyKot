using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float _parallaxEffect;

    private List<SpriteRenderer> _elements = new List<SpriteRenderer>();
    private float _length;
    private float _maxStartPos = -float.MaxValue;
    private float _minStartPos = float.MaxValue;

    private void Start()
    {
        _elements = GetComponentsInChildren<SpriteRenderer>().ToList();
        _length = _elements[0].GetComponent<SpriteRenderer>().bounds.size.x;

        foreach (var element in _elements)
        {
            _minStartPos = Mathf.Min(_minStartPos, element.transform.position.x);
            _maxStartPos = Mathf.Max(_maxStartPos, element.transform.position.x);
        }
    }

    private void LateUpdate()
    {
        for (int i = 0; i < _elements.Count; ++i)
        {
            var element = _elements[i];

            element.transform.position -= Vector3.right * GameManager.Instance.CurrentLevel.MovementSpeed * _parallaxEffect * Time.deltaTime;

            if (element.transform.position.x < _minStartPos - ((_elements.Count - 1) * _length / 2f))
            {
                element.transform.position = _elements[_elements.Count - 1].transform.position + Vector3.right * _length;
                var temp = _elements[_elements.Count - 1];
                _elements[_elements.Count - 1] = _elements[i];
                _elements[i] = temp;
            }
        }
    }
}
