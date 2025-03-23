using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class ClassTouch : MonoBehaviour
{
    [SerializeField] static List<GameObject> _shapesCreated = new List<GameObject>();
    [SerializeField] GameObject _prefab;
    [SerializeField] GameObject trailPrefab;
    GameObject _currentTrail;
    GameObject _selectedObject;

    Sprite _currentSprite;
    static Color _currentColor = Color.white;
    float _lastTapTime = 0f;
    float _doubleTapThreshold = 0.3f;
    Vector2 _startTouchPosition;
    Vector2 _lastPosition;
    bool _swipe = false;
   // bool _createShape = false;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 worldPos = GetWorldPosition(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    HandleTouchBegan(worldPos);
                    break;
                case TouchPhase.Moved:
                    HandleTouchMoved(worldPos);
                    break;
                case TouchPhase.Ended:
                    HandleTouchEnded();
                    break;
            }
        }
    }
    Vector2 GetWorldPosition(Vector2 touchPosition)
    {
        return Camera.main.ScreenToWorldPoint(touchPosition);
    }

    private void HandleTouchBegan(Vector3 worldPos)
    {
        float timeSinceLastTap = Time.time - _lastTapTime;

        if (timeSinceLastTap <= _doubleTapThreshold)
        {
           // _createShape = false;
            RemoveShapeAtPosition(worldPos);
        }
        else
        {

            //if (_createShape == true)
            {
                SpawnShape(worldPos);
            }
            
        }

        _lastTapTime = Time.time;
        _startTouchPosition = worldPos;
        _swipe = true;
        StartTrail(worldPos);
        DetectObjectSelection(worldPos);
    }

    private void HandleTouchMoved(Vector3 worldPos)
    {
        //_createShape = false;
        if (_selectedObject != null)
        {
            _selectedObject.transform.position = worldPos;
        }
        if (_swipe)
        {
            UpdateTrail(worldPos);
        }
    }

    private void HandleTouchEnded()
    {
        //_createShape = false;
        if (_swipe)
        {
            CheckSwipe();
            _swipe = false;
            Destroy(_currentTrail, 0.5f);
        }
        _selectedObject = null;
    }

    private void SpawnShape(Vector3 position)
    {
        if (_currentSprite == null) return;
        GameObject newShape = Instantiate(_prefab, position, Quaternion.identity);
        newShape.GetComponent<SpriteRenderer>().sprite = _currentSprite;
        newShape.GetComponent<SpriteRenderer>().color = _currentColor;
        _shapesCreated.Add(newShape);
        Debug.Log("lista: " + _shapesCreated.Count);
    }

    private void RemoveShapeAtPosition(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider != null && hit.collider.CompareTag("Shape"))
        {
            _shapesCreated.Remove(hit.collider.gameObject);
            Destroy(hit.collider.gameObject);
        }
    }

    private void DetectObjectSelection(Vector3 position)
    {
        RaycastHit2D hit = Physics2D.Raycast(position, Vector2.zero);
        if (hit.collider != null)
        {
            _selectedObject = hit.collider.gameObject;
        }
    }

    private void StartTrail(Vector3 position)
    {
        _currentTrail = Instantiate(trailPrefab, position, Quaternion.identity);
        var trail = _currentTrail.GetComponent<TrailRenderer>();
        trail.startColor = _currentColor;
        trail.endColor = _currentColor;
    }

    private void UpdateTrail(Vector3 position)
    {
        _currentTrail.transform.position = position;
    }

    private void CheckSwipe()
    {
        if (Vector2.Distance(_startTouchPosition, GetWorldPosition(Input.GetTouch(0).position)) > 1f)
        {
            for (int i = 0; i < _shapesCreated.Count; i++)
            {
                Destroy(_shapesCreated[i]);
            }

            _shapesCreated.Clear();

        }
    }

    public void GetColor()
    {
        Image buttonImage = GetComponent<Image>();
        _currentColor = buttonImage.color;
    }

    public void GetImage()
    {
        Image buttonImage = GetComponent<Image>();
        
            _currentSprite = buttonImage.sprite;

    }
}
