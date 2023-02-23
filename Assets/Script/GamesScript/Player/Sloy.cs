using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sloy : MonoBehaviour
{

    [SerializeField] int _sortySloy;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer= GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        _spriteRenderer.sortingOrder = (int)(_sortySloy - transform.position.y);
    }
}
