using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeController : MonoBehaviour
{

    [SerializeField] private float speed = 0.1f;
    [SerializeField] private List<GameObject> defaultPositions = default;
    [SerializeField] private List<GameObject> explodedPositions = default;

    private readonly List<Vector3> explodedPos = new List<Vector3>();
    private readonly List<Vector3> startingPos = new List<Vector3>();

    private bool isInDefaultPosition;
    // Start is called before the first frame update
    private void Start()
    {
        // Cache references
        foreach (var item in defaultPositions) startingPos.Add(item.transform.localPosition);
        foreach (var item in explodedPositions) explodedPos.Add(item.transform.localPosition);
    }

    // Update is called once per frame
    private void Update()
    {
        // Reverse position based on the current position state
            if (isInDefaultPosition)
                // Move objects to exploded positions
                for (var i = 0; i < defaultPositions.Count; i++)
                    defaultPositions[i].transform.localPosition = Vector3.Lerp(
                        defaultPositions[i].transform.localPosition,
                        explodedPos[i], speed);
            else
                // Move objects to default positions
                for (var i = 0; i < defaultPositions.Count; i++)
                    defaultPositions[i].transform.localPosition = Vector3.Lerp(
                        defaultPositions[i].transform.localPosition,
                        startingPos[i], speed);
    }

     /// <summary>
     ///     Toggles the exploded view.
     /// </summary>
    public void Toggle()
    {
        // Toggle the current position state
        isInDefaultPosition = !isInDefaultPosition;
    }
}
