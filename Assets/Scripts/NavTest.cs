using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavTest : MonoBehaviour
{
    [SerializeField]
    private GameObject pre;
    [SerializeField]
    private GameObject p;
    [SerializeField]
    private GameObject q;
    [SerializeField]
    private NavMeshAgent meshAgent;
    [SerializeField]
    private Transform start;
    [SerializeField]
    private Transform target;
    private LineRenderer lineRenderer;
    private void Awake()
    {
        p = Instantiate(pre, start.transform.position,start.transform.rotation);
        meshAgent = p.GetComponent<NavMeshAgent>();
        meshAgent.SetDestination(target.position);
        lineRenderer = GetComponent<LineRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.positionCount = meshAgent.path.corners.Length;
        lineRenderer.SetPositions(meshAgent.path.corners);
        lineRenderer.material.mainTextureOffset = new Vector2(Time.time, 0);
    }
}
