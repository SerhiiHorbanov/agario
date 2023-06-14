using Agario.GameObjects;
using Agario.GameObjects.BlobControllers;
using Agario.States;
using System.Reflection;
using SFML.System;
using SFML.Graphics;
using System.IO;

namespace Agario.SaveAndLoad
{
    static class AgarioSaveLoad
    {
        /*public static void SaveGameObjects()
        {

        }

        public static GameObject[] LoadGameObjects()
        {
            if (File.Exists("save."))
            {

            }
            StreamReader streamReader = new StreamReader("save");

            while (!streamReader.EndOfStream)
            {
                string line = streamReader.ReadLine();
            }
        }

        public static string SerializeCircleObject(CircleObject circleObject)
            => $"Position={SerializeVector2f(circleObject.position)};Color={SerializeColor(circleObject.shape.FillColor)}";

        public static string SerializeBlob(Blob blob)
        {
            bool isAI = blob.controller is AIController;
            return SerializeCircleObject(blob) + $";isAI={isAI};mass={blob.Mass}";
        }


        public static string SerializeFood(Food food)
            => SerializeCircleObject(food);

        public static string SerializeGameObject(GameObject gameObject)
        {
            if (gameObject is Blob)
                return SerializeBlob((Blob)gameObject);
            if (gameObject is Food)
                return SerializeFood((Food)gameObject);
            return "error lol XD";
        }

        public static void DeserializeBlob()
        {

        }

        public static void DeserializeFood()
        {

        }

        private static void SerializeGameObjects()
        {

        }

        private static void DeserializeGameObjects()
        {

        }

        private static void DeserializeInt()
        {

        }

        private static string SerializeVector2f(Vector2f value)
            => $"{value.X},{value.Y}";
        private static string SerializeColor(Color color)
            => $"{color.R},{color.G},{color.B}";*/
    }
}

/*          List<string> fieldStrings = new List<string>();      до речі, ось що я намагався зробити з GameObject-ами

            FieldInfo[] fields = gameObject.GetType().GetFields();

            foreach (FieldInfo field in fields)
            {
                if (!field.IsStatic)
                {
                    string name = field.Name;
                    //string a = $"{name}";
                    string a = $"{name}={gameObject.GetType().GetField(name).GetValue(gameObject).ToString()}";
                    fieldStrings.Add(a);
                }
            }
            return string.Join(",", fieldStrings);*/