using UnityEngine;
using System.Collections;

public class OutLineEff : MonoBehaviour
{
    public Shader baseShader;           // 기본 쉐이더
    public Shader changeShader;         // 선택 되었을때 바꿔 줄 쉐이더
    public Renderer[] renderer;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);    //현재 마우스 클릭한 위치

            renderer = this.gameObject.GetComponentsInChildren<Renderer>();

            foreach (var Renderer in renderer)
            {
                //케릭터에는 충동체가 있어야한다. (Collrider)
                if (Physics.Raycast(ray, out hit) == true)                        // 픽킹(클릭이 되면)이 되면 hit 피킹된 오브젝트 정보가 달려온다.
                {
                    //자신만 피킹되면 hit 쉐이더를 교체한다.
                    if (hit.collider.gameObject == gameObject)
                    {
                        Renderer.material.shader = changeShader;
                    }
                    else
                    {
                        Renderer.material.shader = baseShader;
                    }
                }
                else
                {
                    Renderer.material.shader = baseShader;
                }
            }
        }
    }
}
