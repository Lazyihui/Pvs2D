using System;
using System.Collections.Generic;


public class GoodsRespository
{

    Dictionary<int, Panel_GoodsElement> all;

    Panel_GoodsElement[] temArray;

    public GoodsRespository()
    {
        all = new Dictionary<int, Panel_GoodsElement>();
        temArray = new Panel_GoodsElement[5];
    }

    public void Add(Panel_GoodsElement entity)
    {
        all.Add(entity.id, entity);
    }

    public void Remove(Panel_GoodsElement entity)
    {
        all.Remove(entity.id);
    }

    public int TakeAll(out Panel_GoodsElement[] array)
    {
        if (all.Count > temArray.Length)
        {
            temArray = new Panel_GoodsElement[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out Panel_GoodsElement entity)
    {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<Panel_GoodsElement> action)
    {
        foreach (var item in all.Values)
        {
            action(item);
        }
    }
    public Panel_GoodsElement Find(Predicate<Panel_GoodsElement> predicate)
    {
        foreach (Panel_GoodsElement Goods in all.Values)
        {
            bool isMatch = predicate(Goods);

            if (isMatch)
            {
                return Goods;
            }
        }
        return null;
    }

}