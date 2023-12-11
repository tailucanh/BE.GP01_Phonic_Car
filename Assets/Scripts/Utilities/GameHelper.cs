using System;
using System.ComponentModel;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public static class GameHelper
    {

        public static string GetDescription(Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
        public static void AddComponentsToChildrenWithTag(GameObject gameObject, string name, params System.Type[] componentTypes)
        {
            Transform[] childTransforms = gameObject.GetComponentsInChildren<Transform>();

            foreach (var childTransform in childTransforms)
            {
                if (childTransform.name.Equals(name))
                {
                    foreach (var componentType in componentTypes)
                    {
                        childTransform.gameObject.AddComponent(componentType);
                    }
                }
            }
        }
        public static string ReplaceLastThreeChar(string originalString, string newEnding)
        {
            if (originalString.Length >= 3)
            {
                string firstPart = originalString.Substring(0, originalString.Length - 3);

                string modifiedString = firstPart + newEnding;
                return modifiedString;
            }
            return originalString;
        }

        public static string ReplaceLastFiveChar(string originalString, string newEnding)
        {
             if (originalString.Length >= 5)
            {
                string firstPart = originalString.Substring(0, originalString.Length - 5);

                string modifiedString = firstPart + newEnding;
                return modifiedString;
            }

            return originalString;
        }


        public static float GetCameraTopBound()
        {
            return Camera.main.transform.position.y + Camera.main.orthographicSize;
        }

        public static float GetCameraBottomBound()
        {
            return Camera.main.transform.position.y - Camera.main.orthographicSize;
        }

        public static float GetCameraLeftBound()
        {
            return Camera.main.transform.position.x - (Camera.main.orthographicSize * Camera.main.aspect);
        }

        public static float GetCameraRightBound()
        {
            return Camera.main.transform.position.x + (Camera.main.orthographicSize * Camera.main.aspect);
        }


        public static float GetMiddleX()
        {
            return Camera.main.transform.position.x;
        }

        public static float GetMiddleY()
        {
            return Camera.main.transform.position.y;
        }

        public static int GetInt(string key, int defaultValue = 0)
        {
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public static void SetInt(string key, int value)
        {
            PlayerPrefs.SetInt(key, value);
            PlayerPrefs.Save();
        }

        public static float GetFloat(string key, float defaultValue = 0.0f)
        {
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public static void SetFloat(string key, float value)
        {
            PlayerPrefs.SetFloat(key, value);
            PlayerPrefs.Save();
        }

        public static string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public static void SetString(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
            PlayerPrefs.Save();
        }

        public static bool GetBool(string key, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(key, defaultValue ? 1 : 0) == 1;
        }

        public static void SetBool(string key, bool value)
        {
            PlayerPrefs.SetInt(key, value ? 1 : 0);
            PlayerPrefs.Save();
        }

    }


}
