using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject _grid;

    [SerializeField]
    private int _gridWidth = 7;

    [SerializeField]
    private int _gridHeight = 4;

    [SerializeField]
    private float _cellSpace = 0.2f;

    [SerializeField]
    private GameObject _cellPrefab;

    [SerializeField]
    private GameObject _blockPreefab;

    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Camera _mainCamera;

    public GameObject Player;
    public Dictionary<Vector2, Vector3> _cellPositionByCoords = new Dictionary<Vector2, Vector3>();
    public Dictionary<Vector2, GameObject> _blocksByCoords = new Dictionary<Vector2, GameObject>();
    public static Vector2 CurrentPlayerCoords = new Vector2(3, 0);

    private int _resolutionVertical;
    private int _resolutionHorizontal;
    private float _cameraSize;


    private List<Vector2> _blocks = new List<Vector2>();
    private float _scaleCoeff;


    // Start is called before the first frame update
    private void Start()
    {
        //_resolutionHorizontal = Screen.currentResolution.width;
        //_resolutionVertical = Screen.currentResolution.height;
        float aspectRatio = Camera.main.aspect; //(width divided by height)
        float camSize = Camera.main.orthographicSize; //The size value mentioned earlier
        float correctPositionX = aspectRatio * camSize;
        Camera.main.transform.position = new Vector3(correctPositionX, camSize, -10);
        _resolutionHorizontal = (int)UnityEditor.Handles.GetMainGameViewSize().x;
        _resolutionVertical = (int)UnityEditor.Handles.GetMainGameViewSize().y;

        _cameraSize = _mainCamera.orthographicSize * 2;

        float pixelsPerUnit = CalcPixelsPerUnit(_resolutionVertical, _cameraSize);
        //float scaleCoeff = CalcScaleCoefficient(_resolutionHorizontal, _gridWidth, pixelsPerUnit);
        _scaleCoeff = CalcScaleCoefficient(_resolutionHorizontal, _gridWidth, pixelsPerUnit, _cellSpace);


        //Debug.Log("_resolutionHorizontal " + _resolutionHorizontal);
        //Debug.Log("_resolutionVertical " + _resolutionVertical);
        //Debug.Log("_cameraSize " + _cameraSize);
        //Debug.Log("pixelsPerUnit " + pixelsPerUnit);
        //Debug.Log("scaleCoeff " + scaleCoeff);

        //BuildGrid(scaleCoeff);

        FillBlocsCoords();
        BuildGrid(_scaleCoeff, _cellSpace);
        SpawnPlayer();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    private void SpawnPlayer()
    {
        Player = Instantiate(_playerPrefab, _cellPositionByCoords[CurrentPlayerCoords], Quaternion.identity);
        Player.transform.localScale = new Vector3(_scaleCoeff,_scaleCoeff, _scaleCoeff);
    }

    private void FillBlocsCoords()
    {
        _blocks.Add(new Vector2(0,3));
        _blocks.Add(new Vector2(1,0));
        _blocks.Add(new Vector2(3,2));
        _blocks.Add(new Vector2(5,0));
        _blocks.Add(new Vector2(6,3));
    }

    private void BuildGrid(float scaleCoeff, float cellSpace = 0.0f)
    {
        Vector3 scaleVector = new Vector3(scaleCoeff, scaleCoeff, scaleCoeff);
        
        float positionByScalePointerVertical = 0.0f;
        for(int i = 0; i < _gridHeight; i++)
        {
            float positionByScalePointerHorizontal = 0.0f;
            
            for (int j = 0; j < _gridWidth; j++)
            {
                Vector2 currentCoords = new Vector2(j,i);

                GameObject prefab;

                if(_blocks.Contains(currentCoords))
                {
                    prefab = _blockPreefab;
                }
                else
                {
                    prefab = _cellPrefab;
                }

                var cell = Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
                cell.transform.localScale = new Vector3(cell.transform.localScale.x * scaleCoeff, cell.transform.localScale.y * scaleCoeff, cell.transform.localScale.z * scaleCoeff);
                cell.transform.position = new Vector3(positionByScalePointerHorizontal + cell.transform.localScale.x / 2, positionByScalePointerVertical + cell.transform.localScale.y / 2, 0);
                _cellPositionByCoords.Add(currentCoords, cell.transform.position);

                if (_blocks.Contains(currentCoords))
                {
                    _blocksByCoords.Add(currentCoords, cell);
                }

                cell.transform.SetParent(_grid.transform);

                positionByScalePointerHorizontal += scaleCoeff + cellSpace;
            }

            positionByScalePointerVertical += scaleCoeff + cellSpace;
        }    

    }

    private float CalcPixelsPerUnit(int resolutionVertical, float cameraSize)
    {
        return resolutionVertical / cameraSize;
    }

    private float CalcScaleCoefficient(int resolutionHorisontal, int gridWidth, float pixelsPerUnit)
    {
        return (resolutionHorisontal / gridWidth) / pixelsPerUnit;
    }    
    private float CalcScaleCoefficient(int resolutionHorisontal, int gridWidth, float pixelsPerUnit, float cellSpace)
    {
        return ((resolutionHorisontal-((gridWidth-1)*cellSpace*pixelsPerUnit)) / gridWidth) / pixelsPerUnit;
    }


}
