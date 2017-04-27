using System;
using System.Collections.Generic;
using System.Diagnostics;
using Accord.MachineLearning;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;

namespace Algorithms {

    class BitmapImplementation {
        public void PngToIco(string path) {
            using (FileStream stream = File.OpenWrite(path.Replace("png", "ico"))) {
                Bitmap bitmap = (Bitmap)Image.FromFile(path);
                Icon.FromHandle(bitmap.GetHicon()).Save(stream);
                bitmap.Dispose();
            }
        }
    }

    class Implementation {

        //where T: System.IComparable<T>  
        public void Swap<T>(ref T a, ref T b) { // switch two instances with same property
            T temp = a;
            a = b;
            b = temp;
        }
        public int Compare<T>(T a, T b) { return (a.ToString().CompareTo(b.ToString())); } // compare two instances in form of two strings
        public List<T> ConvertToList<T>(T[] array) { // convert an array to a list
            List<T> list = new List<T>();
            for (int i = 0; i < array.Length; i++) list.Add(array[i]);
            return list;
        }
        public T[] ConvertToArray<T>(List<T> list) { // convert a list to an array
            T[] array = new T[list.Count];
            for (int i = 0; i < list.Count; i++) array[i] = list[i];
            return array;
        }
        public void Print<T>(List<T> str) { for (int i = 0; i < str.Count; i++) Console.Write(str[i] + " "); }
        public void Print<T>(T[] str) { Print(ConvertToList(str)); }
        public void PrintLine<T>(List<T> str) { for (int i = 0; i < str.Count; i++) Console.WriteLine(str[i]); }
        public void PrintLine<T>(T[] str) { PrintLine(ConvertToList(str)); }

    }

    class StringImplementation {
        public string Merge<T>(T[] array) { return Merge(array, ""); }
        public string Merge<T>(T[] array, string sign) {
            string str = array[0].ToString();
            for (int i = 1; i < array.Length; i++) str += "" + sign + array[i];
            return str;
        }

        public bool Appear(string s, string key) {
            return(s.Replace(" ", string.Empty).ToLower().Contains(key.Replace(" ", string.Empty).ToLower()));            
        }
        public bool AppearAny(string s, string[] keys) {
            foreach (string key in keys) 
                if (s.Replace(" ", string.Empty).ToLower().Contains(key.Replace(" ", string.Empty).ToLower())) return true;
            return false;
        }
        public bool AppearAll(string s, string[] keys) {
            foreach (string key in keys)
                if (!s.Replace(" ", string.Empty).ToLower().Contains(key.Replace(" ", string.Empty).ToLower())) return false;
            return true;
        }
    }

    class Sorting {
        Implementation process;
        public void Quicksort<T>(ref List<T> str, int l, int r) {
            int i = l, j = r;
            T x = str[(l + r) >> 1];
            do {
                while (process.Compare<T>(str[i], x) < 0) i++;
                while (process.Compare<T>(str[j], x) > 0) j--;
                if (i <= j) {
                    T temp = str[i];
                    str[i] = str[j];
                    str[j] = temp;
                    //Implementation.Swap<T>(ref str[i], ref str[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (i < r) Quicksort(ref str, i, r);
            if (l < j) Quicksort(ref str, l, j);
        }
        
        public void Quicksort<T>(ref T[] str, int l, int r) {
            int i = l, j = r;
            T x = str[(l + r) >> 1];
            do {
                while (process.Compare<T>(str[i], x) < 0) i++;
                while (process.Compare<T>(str[j], x) > 0) j--;
                if (i <= j) {
                    T temp = str[i];
                    str[i] = str[j];
                    str[j] = temp;
                    //Implementation.Swap<T>(ref str[i], ref str[j]);
                    i++;
                    j--;
                }
            } while (i < j);
            if (i < r) Quicksort(ref str, i, r);
            if (l < j) Quicksort(ref str, l, j);
        }

    }
}
