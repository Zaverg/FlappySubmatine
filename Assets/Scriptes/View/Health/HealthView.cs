using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Image _container;
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
            _images.Add(Instantiate(_image, _container.transform));
        }
    }

    private void OnEnable()
    {
        _health.Changed += ChangeView;
    }

    private void OnDisable()
    {
        _health.Changed -= ChangeView;
    }

    private void ChangeView(float currentLives)
    {
        for (int i = 0; i < _images.Count; i++)
        {
            _images[i].gameObject.SetActive(i < currentLives);
        }
    }
}
