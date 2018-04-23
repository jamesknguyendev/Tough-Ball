using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundColor:MonoBehaviour
{
   
   private List<Color> colors = new List<Color>();
   private Color color;

   public Color GetCurrentColor()
   {
      return color;
   }

   public void MixRandomColor()
   {
      int i  = Random.Range(0, colors.Count);
      color = colors[i];
   }
   
   void Start()
   {
      
//
//      ColorUtility.TryParseHtmlString("#8E9B90", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#C7EFCF", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#934683", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#F5F1ED", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#70798C", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#8AE1FC", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#48B8D0", out color);
//      colors.Add(color);
//      ColorUtility.TryParseHtmlString("#BADEFC", out color);
//      colors.Add(color);
      ColorUtility.TryParseHtmlString("#00BFB3", out color);
      colors.Add(color);
      ColorUtility.TryParseHtmlString("#596475", out color);
      colors.Add(color);
      ColorUtility.TryParseHtmlString("#60A561", out color);
      colors.Add(color);
      ColorUtility.TryParseHtmlString("#7C6C77", out color);
      colors.Add(color);
      ColorUtility.TryParseHtmlString("#EBF8B8", out color); // pale spring rud
      colors.Add(color);
      ColorUtility.TryParseHtmlString("#999AC6", out color);
      colors.Add(color);
      
   }
   
    
}
