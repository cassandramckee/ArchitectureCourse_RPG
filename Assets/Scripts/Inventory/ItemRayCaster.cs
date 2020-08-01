using UnityEngine;

public class ItemRayCaster : ItemComponent
{
    [SerializeField] float _delay = 0.1f;
    [SerializeField] float _range = 10f;
    private int _layermask;
    
    // Can hit up to 100 things at once, if we hit more than 100
    // then the whole thing actually stops working
    private RaycastHit[] _results = new RaycastHit[100];

    private void Awake()
    {
        _layermask = LayerMask.GetMask("Default");
    }

    public override void Use()
    {
        _nextUseTime = Time.time + _delay;

        Ray ray = Camera.main.ViewportPointToRay(Vector3.one / 2f);
        int hits = Physics.RaycastNonAlloc(ray, _results, _range, _layermask, QueryTriggerInteraction.Collide);

        RaycastHit nearest = new RaycastHit();
        double nearestDistance = double.MaxValue;
        for (int i = 0; i < hits; i++)
        {
            var distance = Vector3.Distance(transform.position, _results[i].point);

            if (distance < nearestDistance)
            {
                nearest = _results[i];
                nearestDistance = distance;
            }
        }
        
        if (nearest.transform != null)
        {
            Transform hitCube = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
            hitCube.localScale = Vector3.one * 0.1f;
            // Will eventually sort these and only drop cube a
            hitCube.position = nearest.point; 
        }

    }
}