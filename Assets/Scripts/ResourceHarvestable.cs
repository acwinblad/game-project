using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ResourceHarvestable : ToolHit
{
  [SerializeField] GameObject pickUpDrop;
  [SerializeField] int dropCount = 2;
  [SerializeField] float spread = 1.7f;
  [SerializeField] GameObject child;
  public override void Hit()
  {
    while (dropCount > 0)
    {
      dropCount--;
      Vector2 position = transform.position;
      position.x += spread * UnityEngine.Random.value - spread / 2;
      position.y += spread * UnityEngine.Random.value - spread / 2;
      GameObject go = Instantiate(pickUpDrop);
      go.transform.position = position;
    }
    if (dropCount <= 0)
    {
      if (child != null)
      {
        Vector3 position = transform.position;
        GameObject go = Instantiate(child, position, Quaternion.identity);
        Destroy(gameObject);
      }
      else
      {
        Destroy(gameObject);
      }
    }
  }
}
