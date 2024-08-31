using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioDomain {
    public static AudioEntity Spawn(GameContext ctx, int typeID) {

        bool has = ctx.templateContext.audios.TryGetValue(0, out AudioTM tm);

        if (!has) {
            Debug.LogError("AudioDomain Spawn Error");
            return null;
        }

        ctx.assetsContext.entities.TryGetValue("AudioEntity", out GameObject entity);

        GameObject go = GameObject.Instantiate(entity);
        AudioEntity audioEntity = go.GetComponent<AudioEntity>();

        audioEntity.Ctor();

        audioEntity.SetClip(tm.clip);

        audioEntity.id = ctx.idService.audioIDRecord++;

        ctx.audioRepository.Add(audioEntity);


        return audioEntity;
    }

    public static void UnSpawn(GameContext ctx, AudioEntity audio) {
        ctx.audioRepository.Remove(audio);
        audio.TearDown();
    }
}