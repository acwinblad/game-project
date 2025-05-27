using UnityEngine;

public class ToolController : MonoBehaviour
{
  PlayerController player;
  Rigidbody2D rgdbd2d;
  [SerializeField] float distance = 0.75f;

  private void Awake()
  {
    player = GetComponent<PlayerController>();
    rgdbd2d = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    if (Input.GetMouseButtonDown(0))
    {
      UseTool();
    }
  }

  //private void UseTool()
  //{
  //  Vector2 position = rgdbd2d.position + player.MoveDirection * offsetDistance;
  //  Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);
  //  foreach (Collider2D collider in colliders)
  //  {
  //    ToolHit hit = collider.GetComponent<ToolHit>();
  //    if (hit != null)
  //    {
  //      hit.Hit();
  //      break;
  //    }
  //  }
  //}

  void UseTool()
  {
    RaycastHit2D hit = Physics2D.Raycast(rgdbd2d.position + Vector2.up * 0.2f, player.MoveDirection, distance, LayerMask.GetMask("Interactables"));
    if(hit.collider != null)
    {
      ResourceHarvestable resource = hit.collider.GetComponent<ResourceHarvestable>();
      if (resource != null)
      {
        resource.Hit();
      }
    }
  }

}
