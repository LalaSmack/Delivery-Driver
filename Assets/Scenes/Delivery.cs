using UnityEngine;

public class Delivery : MonoBehaviour
{
   bool hasPackage ;
   [SerializeField] float destoryDelay = 0.5f;
   [SerializeField] Color32 hasPackageColor = new Color32(255, 144, 144, 255);
   [SerializeField] Color32 noPackageColor = new Color32(255, 255, 255, 255);
   SpriteRenderer spriteRenderer;
   private void Start() {
      spriteRenderer = GetComponent<SpriteRenderer>();
   }
   private void OnCollisionEnter2D(Collision2D other)
   {
      Debug.Log("Collision detected with: " + other.gameObject.name);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Package") && !hasPackage)
      {
         Debug.Log("Package Picked Up: " + other.gameObject.name);
         hasPackage = true;
          spriteRenderer.color = hasPackageColor;
         Destroy(other.gameObject, destoryDelay);
        

      }
      else if (other.CompareTag("Customer") && hasPackage)
      {
         Debug.Log("Delivered Package");
         hasPackage = false;
         spriteRenderer.color = noPackageColor;
      }
   }
}
