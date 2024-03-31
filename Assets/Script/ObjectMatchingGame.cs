// using UnityEngine;
// using UnityEngine.EventSystems;


// public class ObjectMachingGame : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
// {
//     private LineRenderer lineRenderer;
//     private GraphicRaycaster raycaster;
//     private PointerEventData pointerData;
//     [SerializeField] private int matchId;

//     public int Get_ID()
//     {
//         return matchId;
//     }


//     void Start()
//     {
//         lineRenderer = GetComponent<LineRenderer>();
//         raycaster = GetComponent<GraphicRaycaster>();
//         pointerData = new PointerEventData(EventSystem.current);
//     }

//     public void OnPointerDown(PointerEventData eventData)
//     {
//         RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<Canvas>().rootCanvas.transform as RectTransform, eventData.position, null, out Vector2 localPoint);
//         lineRenderer.SetPosition(0, localPoint);
//     }

//     public void OnDrag(PointerEventData eventData)
//     {
//         RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<Canvas>().rootCanvas.transform as RectTransform, eventData.position, null, out Vector2 localPoint);
//         lineRenderer.SetPosition(1, localPoint);
//     }

//     public void OnPointerUp(PointerEventData eventData)
//     {
//         pointerData = eventData;
//         CheckForRawImageCollision();
//     }

//     void CheckForRawImageCollision()
//     {
//         RectTransformUtility.ScreenPointToLocalPointInRectangle(transform.parent.GetComponentInParent<Canvas>().rootCanvas.transform as RectTransform, pointerData.position, null, out Vector2 localPoint);
        
//         // Cast a ray to check for RawImage collision
//         RaycastHit2D hit = new RaycastHit2D();

//         if (raycaster.Raycast(pointerData, out hit))
//         {
//             if (hit.transform.gameObject.TryGetComponent(out RawImage rawImage))
//             {
//                 Debug.Log("Collided with RawImage!");
//                 // Perform further actions here
//             }
//         }

//         // Reset line renderer
//         lineRenderer.positionCount = 0;
//         lineRenderer.positionCount = 2;
//     }
// }