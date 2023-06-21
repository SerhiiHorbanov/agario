using Agario.GameObjects;

namespace Agario.Extensions
{
    public static class GameObjectListExtensions//не бийте за назву :skull:
    {
        public static void CheckGameObjectsToDestroy(this List<GameObject> gameObjects)
        {
            for (int i = 0; i < gameObjects.Count; i++)
            {
                GameObject gameObject = gameObjects[i];
                if (gameObject.toDestroy)
                {
                    gameObjects.RemoveAt(i);
                    i--;
                }
            }
        }

        public static void Update(this List<GameObject> gameObjects)
        {
            for (int i = 0; i < gameObjects.Count; i++)
                gameObjects[i].TryUpdate();
        }
    }
}
