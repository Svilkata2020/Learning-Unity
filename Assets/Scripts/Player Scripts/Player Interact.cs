using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private PlayerUI ui;
    private Camera cam;
    public float reachDistance = 3f;
    public LayerMask layer;
    

    private void Start()
    {
        cam = GetComponent<PlayerLook>().cam;
        ui = GetComponent<PlayerUI>();
    }

    private void Update()
    {
        ui.UpdateText("");
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, reachDistance, layer)){
            if(hit.collider.GetComponent<Interactable>() != null){
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                ui.UpdateText(interactable.promptMessage);
            }
        }
    }
}
