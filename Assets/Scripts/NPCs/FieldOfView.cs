using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {

    [SerializeField] private LayerMask layerMask = default;
    [SerializeField] private GameObject guardObject = default;

    private Animator guardAnim;
    private Rigidbody2D guardRig;

    private Mesh mesh;
    private float fov;
    private Vector3 origin;

    private const string 
    WALKING_UP = "WalkingUP", 
    WALKING_DOWN = "WalkingDOWN", 
    WALKING_LR = "WalkingLR";
    
    private const float 
    fovUp = 134f, fovDown = -44f, 
    fovRight = 50f, fovLeft = -130f;

    private float startingAngle = 50f;

    public Animator redScreen = default;

    void Start() {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 90f;
        origin = Vector3.zero;

        guardAnim = guardObject.GetComponent<Animator>();
        guardRig = guardObject.GetComponent<Rigidbody2D>();
    }

    void LateUpdate() {
        // To not disappear when crossing the camera bounds
        mesh.RecalculateBounds();

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 6f;

        #region Fov direction (up, down, left, right)
        if (guardAnim.GetBool(WALKING_LR)) {
            if (guardObject.transform.eulerAngles.y == 0)
                startingAngle = fovRight;
            else
                startingAngle = fovLeft;
        }

        if (guardAnim.GetBool(WALKING_UP))
            startingAngle = fovUp;
 
        else if (guardAnim.GetBool(WALKING_DOWN))
            startingAngle = fovDown;
        #endregion

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++) {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            
            // If raycast doesn't hits anything
            if (raycastHit2D.collider == null) {
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            } else {
                // If the raycast hits the player
                if (raycastHit2D.collider.CompareTag("FovID")) {
                    GameOver();
                    vertex = origin + GetVectorFromAngle(angle) * viewDistance;
                } 
                else {
                    vertex = raycastHit2D.point;
                }
            }

            vertices[vertexIndex] = vertex;

            if (i > 0) {
                triangles[triangleIndex + 0] = 0; 
                triangles[triangleIndex + 1] = vertexIndex - 1; 
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    public void SetOrigin(Vector3 origin) {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection) {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - fov / 2f;
    }

    Vector3 GetVectorFromAngle(float angle) {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    float GetAngleFromVectorFloat(Vector3 dir) {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    void GameOver() {
        redScreen.SetTrigger("GameOver");

        Invoke("RestartLevel", 1.85f);
        
    }

    void RestartLevel() {
        LevelLoader.instance.LoadLevel(6);
    }

    // void OnDrawGizmos() {
    //     float angle = 0f;
    //     int rayCount = 50;
    //     float viewDistance = 50f;

    //     angle = 0;

    //     for (int i = 0; i <= rayCount; i++) {
    //         Gizmos.DrawLine(Vector3.zero, GetVectorFromAngle(angle) * viewDistance);
    //         angle -= 90 / 50;
    //     }
    // }

}
