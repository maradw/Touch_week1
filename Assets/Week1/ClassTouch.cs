using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClassTouch : MonoBehaviour
{
    List<GameObject> _shapesCreated = new List<GameObject>();
    Sprite _currentSprite;
    static Color _currentColor = Color.white; 

    Color _currentWork;

    GameObject _currentToInstance;
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                
                Vector3 worldPos = GetWorldPosition(touch.position);
                SpawnShape(worldPos);
            }
        }
    }

    private Vector2 GetWorldPosition(Vector2 touchPosition)
    {
        
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }

    public void GetColor()
    {
        Image buttonImage = GetComponent<Image>();
        _currentColor = buttonImage.color;
        Debug.Log("color " + _currentColor);
        // return _currentWork;
    }

    public void GetImage()
    {
        _currentSprite = null; // Limpiar antes de asignar
        Image buttonImage = GetComponent<Image>();
        if (buttonImage.sprite != null)
        {
            _currentSprite = buttonImage.sprite;
            Debug.Log("Nueva imagen seleccionada: " + _currentSprite.name);
        }
    }

    private void SpawnShape(Vector3 position)
    {
        if (_currentSprite == null)
        {
            return;
        }

        if (_currentToInstance != null)
        {
            // Si ya hay una forma creada, solo cambia su sprite y color
            SpriteRenderer spriteRenderer = _currentToInstance.GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = _currentSprite;
            spriteRenderer.color = _currentColor;
        }
        else
        {
            // Si no hay una forma creada, crea una nueva
            _currentToInstance = new GameObject("SpawnedObject");
            _currentToInstance.transform.position = position;

            SpriteRenderer spriteRenderer = _currentToInstance.AddComponent<SpriteRenderer>();
            spriteRenderer.sprite = _currentSprite;
            spriteRenderer.color = _currentColor;

            _shapesCreated.Add(_currentToInstance);
        }

        Debug.Log("Imagen actualizada: " + _currentSprite.name);
    }

   
}
