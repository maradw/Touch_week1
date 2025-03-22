﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClassTouch : MonoBehaviour
{
    List<GameObject> _shapesCreated = new List<GameObject>();
    Sprite _currentSprite;
    static Color _currentColor = Color.white;
    [SerializeField] public Transform parentCanvas; 
    Color _currentWork;

     GameObject _currentInstance;
    [SerializeField]GameObject imagePrefab;
    //[SerializeField] GameObject _currentToInstance;
    void Update()
    {
       
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 

            if (touch.phase == TouchPhase.Began)
            {
                
                Vector3 worldPos = GetWorldPosition(touch.position);
                SpawnImage(worldPos);
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
        //_currentSprite = null; // Limpiar antes de asignar
        Image buttonImage = GetComponent<Image>();
        if (buttonImage.sprite != null)
        {
            _currentSprite = buttonImage.sprite;
            Debug.Log("Nueva imagen seleccionada: " + _currentSprite.name);
        }
    }

    /*private void SpawnShape(Vector3 position)
    {
        if (_currentSprite == null)
        {
           // Debug.LogError("No hay imagen seleccionada para spawnear.");
            return;
        }
        
        Debug.Log("color " + _currentColor);
        GameObject newShape = new GameObject("SpawnedObject"); 
        newShape.transform.position = position;


        //_currentToInstance = newShape;
        SpriteRenderer spriteRenderer = _currentToInstance.AddComponent<SpriteRenderer>();
        spriteRenderer.color = _currentColor;
        spriteRenderer.sprite = _currentSprite;

        _shapesCreated.Add(newShape); 

        Debug.Log("Objeto creado en posición: " + position + " con imagen: " + _currentSprite.name + " y color: " + _currentColor);
    }*/
    private void SpawnImage(Vector3 position)
    {
        if (_currentSprite == null || imagePrefab == null || parentCanvas == null)
        {
            Debug.LogError("Falta asignar el sprite, el prefab o el canvas.");
            return;
        }

        _currentInstance = Instantiate(imagePrefab, parentCanvas);
        _currentInstance.transform.position = position;

        Image imageComponent = _currentInstance.GetComponent<Image>();
        if (imageComponent != null)
        {
            imageComponent.sprite = _currentSprite;
            imageComponent.color = _currentColor;
        }

        Debug.Log("Imagen creada en posición: " + position + " con imagen: " + _currentSprite.name + " y color: " + _currentColor);
    }


}
