using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailRen : MonoBehaviour
{
    [SerializeField] private GameObject trailPrefab; // Prefab del objeto con el Trail Renderer
    private GameObject _currentTrail; // Referencia al Trail Renderer activo
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;
    private float swipeThreshold = 50f; // Distancia mínima para considerar un swipe

    [SerializeField] private List<GameObject> _shapesCreated = new List<GameObject>(); // Lista de objetos

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
                SpawnTrail(); // Crear Trail Renderer
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                MoveTrail(touch.position); // Mueve el Trail con el dedo
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                endTouchPosition = touch.position;
                CheckSwipe(); // Detecta si fue un Swipe
                Destroy(_currentTrail, 0.5f); // Destruye el Trail después de 0.5s
            }
        }
    }
    void MoveTrail(Vector2 touchPosition)
    {
        if (_currentTrail != null)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, 10f));
            _currentTrail.transform.position = worldPos;
        }
    }

    void SpawnTrail()
    {
        
    }
    void CheckSwipe()
    {
        float distance = Vector2.Distance(startTouchPosition, endTouchPosition);
        if (distance > swipeThreshold) // Si la distancia del Swipe es suficiente
        {
            Debug.Log("Swipe Detectado! Eliminando objetos...");

            // Eliminar todos los objetos creados
            foreach (GameObject obj in _shapesCreated)
            {
                Destroy(obj);
            }
            _shapesCreated.Clear(); // Vaciar la lista
        }
    }


}
