using System;
using System.Collections;
using UnityEngine;


public static class MapDomain {
    public static MapEntity Spawn(GameContext ctx, int typeID) {
        bool has = ctx.templateContext.maps.TryGetValue(typeID, out MapTM tm);
        ctx.assetsContext.TryGetEntity("MapEntity", out GameObject prefab);
        GameObject go = GameObject.Instantiate(prefab);
        MapEntity map = go.GetComponent<MapEntity>();
        map.Ctor();
        map.typeID = tm.typeID;
        map.SetSprite(tm.sprite);
        map.id = ctx.idService.mapIDRecord++;
        ctx.mapRepository.Add(map);
        return map;
    }
}