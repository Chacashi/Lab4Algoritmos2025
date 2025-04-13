using JetBrains.Annotations;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private string entityName;
     private Vector2 position;


    public string EntityName { set; get; }
    public Vector2 Position {  set; get; }

}
