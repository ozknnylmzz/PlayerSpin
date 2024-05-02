using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.Data
{
    public static class DataSaver
    {
        public static void SetData<T>(string key, T value)
        {
            if (typeof(T) == typeof(int))
            {
                PlayerPrefs.SetInt(key, (int)(object)value);
            }
            else if (typeof(T) == typeof(string))
            {
                PlayerPrefs.SetString(key, (string)(object)value);
            }
            else
            {
                Debug.LogError("Unsupported data type.");
            }
        }

        public static T GetData<T>(string key, T defaultValue = default)
        {
            if (typeof(T) == typeof(int))
            {
                return (T)(object)PlayerPrefs.GetInt(key, (int)(object)defaultValue);
            }
            else if (typeof(T) == typeof(string))
            {
                return (T)(object)PlayerPrefs.GetString(key, (string)(object)defaultValue);
            }
            else
            {
                Debug.LogError("Unsupported data type.");
                return defaultValue;
            }
        }
    }
}