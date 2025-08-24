using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealView : MonoBehaviour
{
    [SerializeField] private Image _continer;
    [SerializeField] private Health _health;
    [SerializeField] private Image _image;

    [SerializeField] private List<Image> _images = new List<Image>();

    public void Reset()
    {
        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].gameObject.SetActive(true);
        }
    }

    private void Awake()
    {
        for (int i = 0; i < _health.MaxCountLives; i++)
        {
            _images.Add(Instantiate(_image, _continer.transform));
        }
    }

    private void OnEnable()
    {
        _health.ChangeHealt += ChangeView;
    }

    private void OnDisable()
    {
        _health.ChangeHealt -= ChangeView;
    }

    private void ChangeView(float countLives)
    {
        int count = _images.Count - (int)countLives - 1;
        Debug.Log(count);

        for (int i = count; i >= 0; i--)
        {
            _images[i].gameObject.SetActive(false);
        }
    }
}
