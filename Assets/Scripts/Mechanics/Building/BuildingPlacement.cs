using UnityEngine;

public class BuildingPlacement : MonoBehaviour
{
    [SerializeField] Transform virtualCamera;
    [SerializeField] LayerMask layerPlaceable;
    private GameObject building;
    private Camera cam;
    private Grid grid;

    private bool isBuilding = false;

    private static BuildingPlacement instance;

    public static BuildingPlacement Instance { get => instance; }

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
        /* if (isBuilding)
        { */
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
        /* } */
        // if (building != null)
        // {
        //     Ray mouseRay = cam.ScreenPointToRay(Input.mousePosition);
        //     float drawPlaneHeight = 0;
        //     float distToDrawPlane = (drawPlaneHeight - mouseRay.origin.y) / mouseRay.direction.y;
        //     Vector3 mousePosition = mouseRay.GetPoint(distToDrawPlane);

        //     building.transform.position = mousePosition;
        // }
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

    public void SetObject(GameObject obj)
    {
        building = Instantiate(obj, Vector3.zero, Quaternion.identity);
        isBuilding = true;
        SetPosition(0);
    }

    public void SetBuild()
    {
        isBuilding = false;
    }
}