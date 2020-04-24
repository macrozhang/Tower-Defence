using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManage : MonoBehaviour
{
    private GameObject selectPanel;         //小菜单1 直接建塔
    // Start is called before the first frame update
    private GameObject nextSelectPanel;     //小菜单2 Build Sell Cancel
    private GameObject firstPanel;          //获取小菜单1
    private GameObject CloseAllNextPanel;   //专门取消 小菜单2
    public GameObject[] towers;             //给GameManage中添加塔的数组以放置塔模型
    private GameObject selectTower;         //即将要创建的塔
    private Transform basePos;              //地基位置，塔的创建位置

    void Start()
    {
        //selectTower = null;
        selectPanel = transform.Find("SelectCanvas").gameObject; // 捕捉名为SelectCanvas的画布 第一个小菜单
        //nextSelectPanel = transform.Find("NextSelectPanel").gameObject; //第二个小菜单


        firstPanel = selectPanel.transform.GetChild(0).gameObject;
        nextSelectPanel = selectPanel.transform.GetChild(1).gameObject;
        CloseAllNextPanel = selectPanel.transform.GetChild(2).gameObject;

        Debug.Log(selectPanel);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SelectBase();
        }
    }

    private void SelectBase() //选择创建塔的砖块
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 50) && EventSystem.current.IsPointerOverGameObject() ==false)
        {                                        //↑并且射线没有点击到UI才执行
            
            if (hit.transform.tag =="TowerBase") //点击带有TowerBase的砖块
            {
                

                ShowSelectPanel(hit.transform);
               

                basePos = hit.transform; //把地基的局部变量传出来

                if (basePos.childCount != 0)
                {
                    Debug.Log("直接显示第二个菜单");
                    firstPanel.SetActive(false);
                    nextSelectPanel.SetActive(false);
                    CloseAllNextPanel.SetActive(true);
                }
            }
        }
    }

    private void ShowSelectPanel(Transform pos)
    {
        

        //selectPanel.transform.SetParent(pos, false);
                 
        selectPanel.transform.localPosition = new Vector3(0, 0, 0);//小菜单位置

        selectPanel.SetActive(true);

        

    }

    public void SelecttowerOne(bool isOn) //选择第一个塔 下以此类推
    {
        if (isOn)
        {
            Debug.Log("SelecttowerOne");
            selectTower = towers[0];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerOTwo(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerTwo");
            selectTower = towers[1];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerThree(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerThree");
            selectTower = towers[2];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void SelecttowerFour(bool isOn)
    {
        if (isOn)
        {
            Debug.Log("SelecttowerFour");
            selectTower = towers[3];
            firstPanel.SetActive(false);
            nextSelectPanel.SetActive(true);
        }
    }

    public void CloseAll()      //关闭所有第一层)
    {
        selectPanel.SetActive(false);
        nextSelectPanel.SetActive(false);//防止第二层窗口开着
        firstPanel.SetActive(true);

    }

    public void CloseNext()     //第二次关闭
    {
        nextSelectPanel.SetActive(false);
        firstPanel.SetActive(true);

    }

    public void CloseAllNext()     //第二次 全部 关闭
    {
        selectPanel.SetActive(false);
        nextSelectPanel.SetActive(false);//防止第二层窗口开着
        firstPanel.SetActive(true);

    }


    public void CreateTower()    //建塔
    {
        if (selectTower != null)
        {
            if (basePos.childCount == 0)
            {
                
                //GameObject temperTower = Instantiate(selectTower,transform.position,Quaternion.identity) as GameObject;
                GameObject temperTower = Instantiate(selectTower);
                temperTower.transform.SetParent(basePos, false);
                temperTower.transform.localPosition = new Vector3(0, 1, 0);
                //temperTower.transform.localScale = new Vector3(0.7F, 0.5F, 0.7F); // 定义尺寸
                //temperTower.AddComponent<Tower_Attake>();     //在此处加 炮塔攻击脚本
                //temperTower.AddComponent<TowerContribute>();  //塔属性脚本
                InitUI();
            }
            else
            {
                Debug.Log("此处已经有塔，不能重复建造");
            }
        }
        else
        {
            Debug.Log("没选中塔");
        }
    }

    public void SellTower()      //卖塔
    {
        //Debug.Log("Sell first");
        //if(basePos.childCount >= 0 ) //判断获取点击目标的UI数目
        //{
        //    Debug.Log("Sell second.");

        //    //Destroy(basePos.GetChild(0).gameObject);
        //    Destroy(basePos.GetChild(1).gameObject);
           
        //    Debug.Log("Sell Succeed.");
        //    InitUI();
        //}
        //else
        //{
        //    Debug.Log("目标地基没有炮台，无法建塔！");
        //}
        int i = 0;
        i = basePos.childCount;

        if (basePos.childCount == 0)
        {
            Debug.Log("目标地基没有炮台，无法建塔！");
        }
        else
        {
            i = basePos.childCount;
            while ((i--)!=0) 
            {
                Destroy(basePos.GetChild(i).gameObject);
            }
            InitUI();
        }

    }

    public void UpgradeTower()      //塔升级
    {
        Debug.Log("Upgrade Tower 塔升级");
        //double OriginHP = HP;
        //double UpgradeHP;
        //double OriginAttackAbility = AttackAbility;
        //double UpgradeAttackAbility;

        //UpgradeHP = OriginHP * 1.2;
        //UpgradeAttackAbility = 1.2 * AttackAbility;

        //double[] a = new double[2] { UpgradeHP, UpgradeAttackAbility };


        //bool flag = UpgradeTower((int)UpgradeHP, (int)UpgradeAttackAbility);
        //return flag;
    }



    private void InitUI()       //初始化UI
    {
        selectTower = null;
        selectPanel.SetActive(false);
        firstPanel.SetActive(true);
        nextSelectPanel.SetActive(false);
        CloseAllNextPanel.SetActive(false);

    }

    //Remark:SelectCanvas 下的 SelectPanel的脚本Toggle Group要及时取消
}
