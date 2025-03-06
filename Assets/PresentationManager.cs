using UnityEngine;

public class PresentationManager : MonoBehaviour
{
    [SerializeField] private RectTransform[] _screens;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] private Vector3[] _screenPositions;
    [SerializeField] float _t = 1.0f;
    float _speed = 2.5f;
    [SerializeField] int _currentScreen = 0;
    [SerializeField] private int _targetScreen;
    float _screenWidth = 2560 * 2;
    Vector3 localPos;
    void Start()
    {
        _screenPositions = new Vector3[_screens.Length * 2];
        for(int i = 0; i < _screens.Length; i++)
        {
            localPos = _screens[i].localPosition;
            localPos.x = _screenWidth * i;
            _screens[i].localPosition = localPos;
            _screenPositions[_screens.Length + i] = localPos;
            localPos.x *= -1;
            _screenPositions[_screens.Length - i] = localPos;
        }
        
    }

    void Update()
    {
        AnimationLoop();
        
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveScreen(_currentScreen + 1);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveScreen(_currentScreen - 1);
        }

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            MoveScreen(0);
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            MoveScreen(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            MoveScreen(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            MoveScreen(3);
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            MoveScreen(4);
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            MoveScreen(5);
        }
        if(Input.GetKeyDown(KeyCode.Alpha7))
        {
            MoveScreen(6);
        }
        if(Input.GetKeyDown(KeyCode.Alpha8))
        {
            MoveScreen(7);
        }
        if(Input.GetKeyDown(KeyCode.Alpha9))
        {
            MoveScreen(8);
        }
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            MoveScreen(9);
        }
    }
    
    private void AnimationLoop()
    {
        if (_t < 1)
        {
           _t += Time.deltaTime * _speed;
           for (int i = 0; i < _screens.Length; i++)
           {
               int iScreen = _screens.Length + (_currentScreen - i);
               Vector3 startPos = _screenPositions[iScreen];
               int targetScreen = _screens.Length + (_targetScreen - i);
               Vector3 targetPos = _screenPositions[targetScreen];
               //print("for i = " + i + " iScreen = " + iScreen + "targetScreen = " + targetScreen + " _currentScreen = " + _currentScreen + " _targetScreen = " + _targetScreen);
               localPos = Vector3.Lerp(startPos, targetPos, _curve.Evaluate(_t));
               _screens[i].localPosition = localPos;
           }
        }
        else
        {
            _currentScreen = _targetScreen;
        }
    }
    
    public void MoveScreen(int targetScreen)
    {
        _targetScreen = targetScreen;
        _t = 0;
    }
}
