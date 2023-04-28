using UnityEngine;

public class TestScript : MonoBehaviour
{
    //private Transform m_Transform;

    [SerializeField] private Transform vector;
    [SerializeField] private Transform normal;
    [SerializeField] private Transform result;

    //[SerializeField] private float speed = 5f;

    private void Start()
    {
        //m_Transform = GetComponent<Transform>();

    }
    
    private void Update()
    {
        result.position = Vector3.Project(vector.position - normal.position, normal.forward) + normal.position;
        
        Debug.DrawRay(normal.position, (result.position - normal.position) * 5, Color.blue);
        Debug.DrawRay(normal.position, vector.position - normal.position, Color.green);
        Debug.DrawRay(vector.position, result.position - vector.position, Color.red);
        

        //var dir_vertical = m_Transform.forward * Input.GetAxis("Vertical");
        //var dir_horizontal = m_Transform.right * Input.GetAxis("Horizontal");

        //m_Transform.position += (dir_vertical + dir_horizontal) * speed * Time.deltaTime;
    }

}
































//private void Update()
//{
//    if(Input.GetKeyDown(KeyCode.Alpha1))
//    {
//        CutsceneManager.Instance.StartCutscene("Cutscene_1");
//    }

//    if (Input.GetKeyDown(KeyCode.Alpha2))
//    {
//        CutsceneManager.Instance.StartCutscene("Cutscene_2");
//    }
//}