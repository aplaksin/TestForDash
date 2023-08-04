using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.GraphicsBuffer;

[DefaultExecutionOrder(100)]
public class SwipeDetection : MonoBehaviour
{
    [SerializeField]
    private GridGenerator _gridGenerator;

    private GameObject _player;

    [SerializeField]
    private Vector2 _currentPlayerCoords;

    private Dictionary<Vector2, Vector3> _cellPositionByCoords = new Dictionary<Vector2, Vector3>();
    private Dictionary<Vector2, GameObject> _blocksByCoords = new Dictionary<Vector2, GameObject>();

    [SerializeField]
    private float minSwipeDistance = 0.2f;

    [SerializeField]
    private float maxSwipeTime = 1f;

    [SerializeField]
    private InputManager _inputManager;

    [SerializeField, Range(0.05f,1)]
    private float _directionTrashold = 0.9f;

    private Vector2 _startPosition;
    private float _startTime;
    private Vector2 _endPosition;
    private float _endTime;

    [SerializeField]
    private bool _isMoving = false;

    [SerializeField]
    private Vector3 _movePosition;

    [SerializeField]
    private float _moveSpeed = 1f;

    private GameObject _fireBlock;

    private void Awake()
    {
        //_inputManager = InputManager.Instance;

    }

    // Start is called before the first frame update
    void Start()
    {
        
        _currentPlayerCoords = GridGenerator.CurrentPlayerCoords;
        _cellPositionByCoords = _gridGenerator._cellPositionByCoords;
        _blocksByCoords = _gridGenerator._blocksByCoords;
        _player = _gridGenerator.Player;
    }

    // Update is called once per frame
    void Update()
    {
        if(_movePosition != Vector3.zero)
        {
            _isMoving = true;
            var step = _moveSpeed * Time.deltaTime; // calculate distance to move
            _player.transform.position = Vector3.MoveTowards(_player.transform.position, _movePosition, step);

            if (Vector3.Distance(_player.transform.position, _movePosition) < 0.001f)
            {
                
                _player.transform.position = _movePosition;
                _movePosition = Vector3.zero;
                _isMoving = false;
                if(_fireBlock != null)
                {
                    Debug.Log("FIRE!!!!!!!!!!!");
                    _fireBlock = null;
                }
            }
        }
    }



    private void SwipeEnd(Vector2 position, float time)
    {
        _endPosition = position;
        _endTime = time;
        DetectSwipe();
    }

    private void SwipeStart(Vector2 position, float time)
    {
        _startPosition = position;
        _startTime = time;
    }

    private void DetectSwipe()
    {
        if(Vector3.Distance(_startPosition, _endPosition) >= minSwipeDistance 
            && _endTime - _startTime <= maxSwipeTime)
        {
            Debug.DrawLine(_startPosition, _endPosition, Color.red, 2f);
            //Debug.Log("swipe");
            Vector2 direction = _endPosition - _startPosition;
            Vector2 direction2D = new Vector2(direction.x, direction.y).normalized;
            Vector2 directionVector = SwipeDirection(direction2D);
            CalcMovePlayerPosition(directionVector);
        }
    }

    private Vector2 SwipeDirection(Vector2 direction)
    {

        Vector2 directionVector = Vector2.zero;

        if (Vector2.Dot(Vector2.up, direction) > _directionTrashold)
        {
            Debug.Log("Swipe UP");
            directionVector = Vector2.up;
        }

        if (Vector2.Dot(Vector2.down, direction) > _directionTrashold)
        {
            Debug.Log("Swipe DOWN");
            directionVector = Vector2.down;
        }

        if (Vector2.Dot(Vector2.left, direction) > _directionTrashold)
        {
            Debug.Log("Swipe LEFT");
            directionVector = Vector2.left;
        }

        if (Vector2.Dot(Vector2.right, direction) > _directionTrashold)
        {
            Debug.Log("Swipe RIGHT");
            directionVector = Vector2.right;
        }

        return directionVector;
    }

    private void CalcMovePlayerPosition(Vector2 direction)
    {
        Vector2 currentDirection = direction;
        Vector3 moveTarget = Vector3.zero;

        if(!_isMoving && currentDirection != Vector2.zero)
        {
            while(_cellPositionByCoords.ContainsKey(_currentPlayerCoords+direction) && !_blocksByCoords.ContainsKey(_currentPlayerCoords + direction))
            {
                currentDirection = _currentPlayerCoords + direction;
                _currentPlayerCoords = currentDirection;
                moveTarget = _cellPositionByCoords[currentDirection];
                Debug.Log(moveTarget);
                if(_blocksByCoords.ContainsKey(_currentPlayerCoords + direction))
                {
                    _fireBlock = _blocksByCoords[currentDirection+direction];
                }
            }

            _movePosition = moveTarget;
        }



    }

    private void OnEnable()
    {
        _inputManager.OnStartTouch += SwipeStart;
        _inputManager.OnEndTouch += SwipeEnd;
    }

    private void OnDisable()
    {
        _inputManager.OnStartTouch -= SwipeStart;
        _inputManager.OnEndTouch -= SwipeEnd;
    }
    

}
