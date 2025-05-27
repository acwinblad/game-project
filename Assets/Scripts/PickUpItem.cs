using UnityEngine;

public class PickUpItem : MonoBehaviour
{
  Transform player;
  [SerializeField] float speed = 5f;
  [SerializeField] float pickUpDistance = 2.0f;
  [SerializeField] float ttl = 10f;

  void Awake()
  {
    player = GameManager.instance.player.transform;
  }

  void Update()
  {
    ttl -= Time.deltaTime;
    if (ttl < 0) { Destroy(gameObject); }

    float distance = Vector2.Distance(transform.position, player.position); ;
    if(distance > pickUpDistance)
    {
      return;
    }
    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
    if (distance < 0.1f)
    {
      Destroy(gameObject); 
    }
  }
}
