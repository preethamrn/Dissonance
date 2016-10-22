using UnityEngine;
using System.Collections;
using System.Collections.Generic; //for List!

public class Projectile
{
    public Projectile(int type, int lane, GameObject obj)
    {
        this.obj = obj;
        m_type = type;
        m_lane = lane;

        switch(type)
        {
            case 1:
                m_height = 1;
                m_velocity = 1;
                break;
            case 2:
                m_height = ApplicationModel.height - 2;
                m_velocity = -1;
                break;
            default:
                //Debug.Log("Error, not correct type for projectile");
                break;       
        }
    }

    public int m_velocity;
    public int m_type;
    public int m_lane;
    public int m_height;
    public GameObject obj;
}

public class ProjectileScript : MonoBehaviour {
    
    List<Projectile> projectileList = new List<Projectile>();
    
	public void move () {
        for (int i = 0; i < projectileList.Count; i++) {
            projectileList[i].m_height += projectileList[i].m_velocity;

            //have some effect if player is there, and delete
            if (projectileList[i].m_height <=0 || projectileList[i].m_height >= 8) {
                Destroy(projectileList[i].obj);
                projectileList.RemoveAt(i);
                i--; //upper elements shift down into empty spot, check index again
                continue;
            }

            projectileList[i].obj.transform.position = new Vector2(projectileList[i].obj.transform.position.x, -14 + 4*projectileList[i].m_height);
        }
	}

    public void addProjectile(int type, int lane, GameObject obj) {
        //Debug.Log("adding projectile of type " + type + " on lane " + lane);
        projectileList.Add(new Projectile(type, lane, obj));
        int i = projectileList.Count - 1;
        projectileList[i].obj.transform.position = new Vector2(ApplicationModel.xRatio * 2 / 5 * (float)(projectileList[i].m_lane + 0.5) - ApplicationModel.xRatio, -14 + 4 * projectileList[i].m_height);
    }

    public void animate() {
        foreach (Projectile p in projectileList) {
            p.obj.GetComponent<Animator>().SetTrigger("pulse");
        }
    }
}
