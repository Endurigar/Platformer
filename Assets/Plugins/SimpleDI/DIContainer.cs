using SimpleDI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UIElements;

public sealed class DIContainer : Singleton<DIContainer>
{
    private List<Item> items = new List<Item>();
    private List<Behaviour> bindClassList = new List<Behaviour>();
  
    void Start()
    {
        BindItemsOnScene();
        InjectNeededItems();
    }

    private void BindItemsOnScene()
    {
        var classes = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
        foreach (var classItem in classes)
        {
            var type = classItem.GetType();
            if (type.GetCustomAttribute<BindClassMarker>() != null)
            {
               Item item = new Item();
                item.Object = classItem;
                item.Type = type;
                items.Add(item);
            }
        }
      
    }

    private void InjectNeededItems()
    {
        var classes = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
        foreach (var classItem in classes)
        {
            
            var type = classItem.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Instance);
            foreach (var field in fields)
            {
                if (field.GetCustomAttribute<Inject>() != null)
                {
                   field.SetValue(classItem, Resolve(field.FieldType));
                }
            }
           
        }
    }

    private Behaviour Resolve(Type type)
    {
        foreach(var item in items)
        {
            if(item.Type == type)
            {
                return item.Object;
            }
        }
        throw new NotImplementedException();
    }
    public void RealtimeBind(Behaviour behaviour)
    {
        var item = new Item();
        item.Object = behaviour;
        item.Type = behaviour.GetType();
        items.Add(item);
        RealtimeInject();
    }
    private void RealtimeInject()
    {
        var classes = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.InstanceID);
        foreach (var classItem in classes)
        {
            
            var type = classItem.GetType();
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Instance);

            bool flag = false;
            foreach (var field in fields)
            {
               
                if (field.GetCustomAttribute<RealtimeInject>() != null)
                {
                    flag = true;
                    field.SetValue(classItem, Resolve(field.FieldType));
                   
                }
            }
            if(flag)
            RealtimeCallback(classItem.GetType(), classItem);
            }
    }
    
    private void RealtimeCallback(Type type, Behaviour behaviour)
    {
        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Default | BindingFlags.Instance);
        foreach(var method in methods)
        {
            if(method.GetCustomAttribute<RealtimeInjectCallback>() != null)
            {
                method.Invoke(behaviour, null);
                break;
            }
        }
    }
}
