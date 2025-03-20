using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Assets.Week1
{
    public class ClassTouch : MonoBehaviour
    {
        [SerializeField] GameObject[] _colors;
        [SerializeField] GameObject[] _images;
        [SerializeField] public Image mySpr;
        private Button oño;

        Color _currentColor;
        //SpriteTG  _curretSprite;

        // Use this for initialization
        void Start()
        {
            oño = GetComponent<Button>();

            Debug.Log("NOSE");
            for (int i = 0; i < _colors.Length; i++) 
            {
                //_colors[i].tintColor = Color.white;
            }
           // Debug.Log("ola" + mySpr.name);

        }
        
        // Update is called once per frame
        void Update()
        {
           // Instantiate(_images[1]);
            if (Input.touchCount > 0)
            {
               // Instantiate(_images[1]);
                Touch currentTouch = Input.GetTouch(0);
                //Instantiate(_images[1]);
                if (currentTouch.phase == TouchPhase.Began)
                {
                   // Debug.Log("Touch");

                }
            }
            
        }
        void InstantiateImage()
        {
            Instantiate(_images[1]);
        }
        public void GetImage()
        {
            if(mySpr == null)
            {
                mySpr = _images[1].GetComponent<Image>();
                Debug.Log("cambio?" + mySpr.name);
                
            }
            //mySpr = _images[1].GetComponent<Image>() ;
            //Debug.Log("cambio?" + mySpr.name);

        }
    }
}