using UnityEngine;
using System.Collections.Generic;
using System;
#if NETFX_CORE
using System.Reflection;
#endif

namespace XD
{
    public static class ExtensionMethods
    {
        public static float Round(this float value, int power)
        {
            float pow = Mathf.Pow(10, power);
            return Mathf.Round(value * pow) / pow;
        }

        public static string ToHex(this Color color)
        {
            string hex = "#" + color.r.ToColor().ToString("X2") + color.g.ToColor().ToString("X2") + color.b.ToColor().ToString("X2");
            return hex;
        }

        public static int ToColor(this float val)
        {
            return (int)(255 * val);
        }

        public static string GetTimeString(this System.DateTime dateTime)
        {
            string time = (dateTime.Hour < 10 ? "0" : "") + dateTime.Hour + ":" + (dateTime.Minute < 10 ? "0" : "") + dateTime.Minute + ":" + (dateTime.Second < 10 ? "0" : "") + dateTime.Second;
            return time;
        }

        public static string Concat(this string[] value, int startIndex = 5, int maxCount = -1)
        {
            if (value == null)
            {
                return "";
            }
            string result = "";
            if (maxCount == -1)
            {
                maxCount = value.Length;
            }

            for (int i = startIndex; i < startIndex + Mathf.Min(maxCount, value.Length - startIndex); i++)
            {
                result += "\n" + value[i];
            }
            return result;
        }

        public static string GetName<T>(this T target) where T : Component
        {
            if (target == null)
            {
                return "NULL";
            }
            return target.name;
        }

        public static float AngleSigned(this Vector3 v1, Vector3 v2, Vector3 n)
        {
            return Mathf.Atan2(
                Vector3.Dot(n, Vector3.Cross(v1, v2)),
                Vector3.Dot(v1, v2)) * Mathf.Rad2Deg;
        }

        public static List<Transform> FindRecursivelyArray(this Transform transform, string name)
        {
            if (transform == null)
            {
                return new List<Transform>();
            }
            List<Transform> result = new List<Transform>();
            Transform founded = transform.FindChild(name);
            if (founded != null)
            {
                result.Add(founded);
            }
            else
            {
                foreach (Transform child in transform)
                {
                    result.AddRange(child.FindRecursivelyArray(name));                    
                }
            }
            return result;
        }

        public static Transform FindRecursively(this Transform transform, string name)
        {
            Transform result = transform.FindChild(name);
            if (result == null)
            {
                foreach (Transform child in transform)
                {
                    result = child.FindRecursively(name);
                    if (result != null)
                    {
                        break;
                    }
                }
            }
            return result;
        }

        public static T GetOrAdd<T>(this GameObject gameObject) where T : MonoBehaviour
        {
            T comp = gameObject.GetComponent<T>();
            if (comp == null)
            {
                comp = gameObject.AddComponent<T>();
            }
            return comp;
        }

        public static T RandomElement<T>(this object[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                return default(T);
            }
            return (T)parameters[UnityEngine.Random.Range(0, parameters.Length)];
        }

        public static string FormatString(this string need, string format)
        {
            Dictionary<TextParameter, string> dict = new Dictionary<TextParameter, string>();
            string[] lst = format.Split(new char[] { ';' });
            for (int i = 0; i < lst.Length; i++)
            {
                string[] tmp = lst[i].Split(new char[] { ':' });
                if (tmp[0].ToLower() == "color")
                {
                    dict.Add(TextParameter.Color, tmp[1]);
                }
                if (tmp[0].ToLower() == "size")
                {
                    dict.Add(TextParameter.Size, tmp[1]);
                }
                if (tmp[0].ToLower() == "style")
                {
                    dict.Add(TextParameter.Style, tmp[1]);
                }
            }

            return need.SetFormating(dict);
        }

        public static string SetFormating(this string need, Dictionary<TextParameter, string> parameters)
        {
            string res = need;
            if (parameters.ContainsKey(TextParameter.Color))
            {
                res = string.Format("<color={0}>{1}</color>", parameters[TextParameter.Color], res);
            }
            if (parameters.ContainsKey(TextParameter.Size))
            {
                res = string.Format("<size={0}>{1}</size>", parameters[TextParameter.Size], res);
            }
            if (parameters.ContainsKey(TextParameter.Style))
            {
                string[] tmp = parameters[TextParameter.Style].Split(new char[] { ',' });
                for (int i = 0; i < tmp.Length; i++)
                {
                    res = string.Format("<{0}>{1}</{0}>", tmp[i], res);
                }
            }
            return res;
        }

        public static void SetLayer(this GameObject gameObject, int layer)
        {
            if (gameObject == null)
            {
                return;
            }
            gameObject.layer = layer;
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetLayer(layer);
            }
        }


        public static void SetEffectsAlpha(this ParticleSystem[] effects, float alpha)
        {
            for (int i = 0; i < effects.Length; i++)
            {
                SetEffectAlpha(effects[i], alpha);
            }
        }

        public static void SetEffectAlpha(this ParticleSystem particleSystem, float alpha)
        {
            Color color = particleSystem.startColor;
            color.a = alpha;
            particleSystem.startColor = color;

        }


        public static T Get<T>(this object[] parameters, int index = 0)
        {
            T result = default(T);
            int currentIndex = -1;
            Type targetType = typeof(T);
#if NETFX_CORE
            TypeInfo targetTypeInfo = targetType.GetTypeInfo();
#else            
            Type targetTypeInfo = targetType;
#endif
            for (int i = 0; i < parameters.Length; i++)
            {
                if (parameters[i] == null)
                {
                    continue;
                }
#if NETFX_CORE
                TypeInfo type = parameters[i].GetType().GetTypeInfo();
#else
                Type type = parameters[i].GetType();
#endif

                if (type.IsAssignableFrom(targetTypeInfo) || type.IsSubclassOf(targetType))
                {
                    currentIndex++;
                    result = (T)parameters[i];
                    if (currentIndex == index)
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
