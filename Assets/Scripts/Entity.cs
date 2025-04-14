
using UnityEngine;

public class Entity 
{
     private string entityName;
    private int life;
    private Vector2 position;

    public Vector2 Position { set {  position = value; } get { return position; } }
    public string EntityName { set { entityName = value; } get { return entityName; } }
    public int Life { set { life = value; } get { return life; } }


    public Entity()
    {
        position = Vector2.zero;
        entityName ="";
        life = 100;
    }
    

}
