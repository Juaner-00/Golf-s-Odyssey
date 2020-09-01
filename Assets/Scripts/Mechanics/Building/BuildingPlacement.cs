using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] GameObject buildBtn;
    [SerializeField] Transform virtualCamera;
    [SerializeField] LayerMask layerPlaceable;
    private GameObject building;
    private Camera cam;
    private Grid grid;

    private bool isBuilding = false;

    private static BuildingPlacement instance;

    public static BuildingPlacement Instance { get => instance; }
    public bool IsBuilding { get => isBuilding; }
    public LayerMask LayerPlaceable { get => layerPlaceable; }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);

        grid = FindObjectOfType<Grid>();
    }

    private void Start()
    {
        cam = Camera.main;
        // cam.transform.position += grid.GetOffset();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            SetPosition(0);
        }
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
                SetPosition(1);
        }
    }

    private void SetPosition(int i)
    {
        // Mover la cámara
        if (i == 0)
            virtualCamera.position += InputManager.deltaMousePos;
        else
            virtualCamera.position += InputManager.deltaTouchPos;

        if (isBuilding)
        {
            float posY;
            RaycastHit hit;

            Ray ray = cam.ScreenPointToRay(virtualCamera.position);

            if (Physics.Raycast(ray, out hit, 50, layerPlaceable))
                posY = hit.point.y;
            else
                posY = 0;

            // Mover el objeto a la posicion del Raycast o a 0 (en y)
            Vector3 newPos = grid.Snap(virtualCamera.position - grid.GetOffset()) + grid.GetOffset();
            newPos.y = posY;
            building.transform.position = newPos;
        }
    }

    public void InstanciateObject(GameObject obj)
    {
        building = Instantiate(obj, Vector3.zero, Quaternion.identity);
        isBuilding = true;
        SetPosition(0);
        buildBtn.SetActive(false);
    }

    public void SetObject(Vector3 pos, GameObject obj)
    {
        grid.SetState(pos);
        building = obj;
        isBuilding = true;
        // SetPosition(0);
        buildBtn.SetActive(false);
    }

    public void SetBuild(Vector3 pos, GameObject obj)
    {
        if (grid.GetState(pos))
        {
            grid.SetState(pos);
            if (obj == building)
            {
                isBuilding = false;
                buildBtn.SetActive(true);
            }
        }
    }

    public bool CanPlace(Vector3 pos)
    {
        return grid.GetState(pos) ? true : false;
    }

    public void DeleteBuild(Vector3 pos, GameObject obj)
    {
        if (obj == building)
        {
            isBuilding = false;
            buildBtn.SetActive(true);
        }
    }
}