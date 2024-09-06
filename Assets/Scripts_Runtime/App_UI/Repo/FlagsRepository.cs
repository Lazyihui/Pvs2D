using System;
using System.Collections.Generic;


public class FlagRespository {

    Dictionary<int, Panel_ProcessFlag> all;

    Panel_ProcessFlag[] temArray;

    public FlagRespository() {
        all = new Dictionary<int, Panel_ProcessFlag>();
        temArray = new Panel_ProcessFlag[5];
    }

    public void Add(Panel_ProcessFlag entity) {
        all.Add(entity.id, entity);
    }

    public void Remove(Panel_ProcessFlag entity) {
        all.Remove(entity.id);
    }

    public int TakeAll(out Panel_ProcessFlag[] array) {
        if (all.Count > temArray.Length) {
            temArray = new Panel_ProcessFlag[all.Count * 2];
        }
        all.Values.CopyTo(temArray, 0);

        array = temArray;
        return all.Count;

    }

    public bool TryGet(int id, out Panel_ProcessFlag entity) {
        return all.TryGetValue(id, out entity);
    }

    public void Foreach(Action<Panel_ProcessFlag> action) {
        foreach (var item in all.Values) {
            action(item);
        }
    }
    public Panel_ProcessFlag Find(Predicate<Panel_ProcessFlag> predicate) {
        foreach (Panel_ProcessFlag Flag in all.Values) {
            bool isMatch = predicate(Flag);

            if (isMatch) {
                return Flag;
            }
        }
        return null;
    }

}