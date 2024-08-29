using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioDomain {
    public static AudioEntity Spawn(GameContext ctx) {
        bool has = ctx.assetsContext.entities.TryGetValue("AudioEntity", out GameObject entity);
        if (!has) {
            Debug.LogError("没有这个预制体");
            return null;
        }

        GameObject go = GameObject.Instantiate(entity);
        AudioEntity audioEntity = go.GetComponent<AudioEntity>();

        audioEntity.Ctor();
        audioEntity.id = ctx.idService.audioIDRecord++;

        ctx.audioRepository.Add(audioEntity);


        return audioEntity;
    }
}