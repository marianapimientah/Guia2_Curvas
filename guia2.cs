using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

//Presentado por Mariana Pimienta Hernandez
public class guia2 : MonoBehaviour
{
    Texture2D texture;
    static readonly Stopwatch timer = new Stopwatch();
    void Start()
    {
        Color Back = new Color(0, 0, 0, 1);
        Setup(64, 64, Back);

        //Azul
        timer.Start();
        double Tinicial0=timer.Elapsed.TotalMilliseconds;
        Color LineColor = new Color(0, 0, 1, 1);
        Abressenham(5, 5, 5, 60, LineColor);
        texture.Apply();
        double Tfinal0 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal0=Tfinal0 - Tinicial0;
        print(Ttotal0);

        //Cian
        timer.Start();
        double Tinicial1 = timer.Elapsed.TotalMilliseconds;
        Color LineColor1 = new Color(0, 1, 1, 1);
        Abressenham(45, 5, 45, 60, LineColor1);
        texture.Apply();
        double Tfinal1 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal1 = Tfinal1 - Tinicial1;
        print(Ttotal1);

        //Rosado
        timer.Start();
        double Tinicial2 = timer.Elapsed.TotalMilliseconds;
        Color LineColor2 = new Color(1, 0, 1, 1);
        Abressenham(20, 5, 20, 60, LineColor2);
        texture.Apply();
        double Tfinal2 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal2 = Tfinal2 - Tinicial2;
        print(Ttotal2);

        //Verde
        timer.Start();
        double Tinicial3 = timer.Elapsed.TotalMilliseconds;
        Color LineColor3 = new Color(0, 1, 0, 1);
        Abressenham(60, 5, 60, 60, LineColor3);
        texture.Apply();
        double Tfinal3 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal3 = Tfinal3 - Tinicial3;
        print(Ttotal3);

        //Rojo
        timer.Start();
        double Tinicial4 = timer.Elapsed.TotalMilliseconds;
        Color LineColor4 = new Color(1, 0, 0, 1);
        Abressenham(30, 5, 30, 60, LineColor4);
        texture.Apply();
        double Tfinal4 = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal4 = Tfinal4 - Tinicial4;
        print(Ttotal4);

        //Lineas Horizontales
        //x,y,x1,y2

        //Azul
        timer.Start();
        double Tinicial0H = timer.Elapsed.TotalMilliseconds;
        Color LineColorH = new Color(0, 0, 1, 1);
        Abressenham(5, 10, 60, 10, LineColorH);
        texture.Apply();
        double Tfinal0H = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal0H = Tfinal0H - Tinicial0H;
        print(Ttotal0H);

        //Cian
        timer.Start();
        double Tinicial1H = timer.Elapsed.TotalMilliseconds;
        Color LineColor1H = new Color(0, 1, 1, 1);
        Abressenham(5, 20, 60, 20, LineColor1H);
        texture.Apply();
        double Tfinal1H = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal1H = Tfinal1H - Tinicial1H;
        print(Ttotal1H);

        //Rosado
        timer.Start();
        double Tinicial2H = timer.Elapsed.TotalMilliseconds;
        Color LineColor2H = new Color(1, 0, 1, 1);
        Abressenham(5, 30, 60, 30, LineColor2H);
        texture.Apply();
        double Tfinal2H = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal2H = Tfinal2H - Tinicial2H;
        print(Ttotal2H);

        //Verde
        timer.Start();
        double Tinicial3H = timer.Elapsed.TotalMilliseconds;
        Color LineColor3H = new Color(0, 1, 0, 1);
        Abressenham(5, 40, 60, 40, LineColor3H);
        texture.Apply();
        double Tfinal3H = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal3H = Tfinal3H - Tinicial3H;
        print(Ttotal3H);

        //Rojo
        timer.Start();
        double Tinicial4H = timer.Elapsed.TotalMilliseconds;
        Color LineColor4H = new Color(1, 0, 0, 1);
        Abressenham(5, 50, 60, 50, LineColor4H);
        texture.Apply();
        double Tfinal4H = timer.Elapsed.TotalMilliseconds;
        timer.Stop();
        double Ttotal4H = Tfinal4H - Tinicial4H;
        print(Ttotal4H);
    }

    public void Setup(float H, float W, Color Back)
    {
        texture = new Texture2D((int)H, (int)W);
        GetComponent<Renderer>().material.mainTexture = texture;
        for(int y = 0; y <texture.height; y++)
        {
            for(int x = 0; x <texture.width; x++)
            {
                texture.SetPixel(x, (int)H - y - 1, Back);
            }
        }
    }
    public void ABasico(float x0,float y0, float x1, float y1, Color line)
    {
        if(x0 == x1)
        {
            if (y1 > y0)
            {
                for(int y = (int)y0; y <= y1; y++)
                {
                    texture.SetPixel((int)x0,y,line);
                }
            }
            else
            {
                for(int y = (int)y1; y <= y1; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
        }
        
            float m = (y1 - y0) / (x1 - x0);
            float b = y0 - m * x0;
           
        

        float yb = y0;
        if (x0> x1)
        {
            
            for (int x = (int)x1; x <= x0; x++)
            {
                float y = m * x + b;
                if (Mathf.Abs(m) >= 1 && x > x1)
                {
                    ABasico(x, yb, x, y, line);
                }
                texture.SetPixel((int)x, (int)y, line);
                yb = y;
            }
        }
        else
        {
            for(int x=(int)x0;x<=x1; x++)
            {
                float y = m * x + b;
                if (Mathf.Abs(m) >= 1 && x > x0)
                {
                    ABasico(x, yb, x, y, line);
                }
                texture.SetPixel((int)x, (int)y, line);
                yb = y;
            }
        }
    }
    void Abressenham(int x, int y, int x2, int y2, Color color)
    {
        int w = x2 - x;
        int h= y2 - y;
        int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
        if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
        if(h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
        if(w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
        int longest = Mathf.Abs(w);
        int shortest = Mathf.Abs(h);
        if (!(longest > shortest))
        {
            longest = Mathf.Abs(h);
            shortest = Mathf.Abs(h);
            if (h < 0) dy2 = -1;else if (h>0) dy2 = 1;
            dx2=0;
        }
        int numerator = longest >> 1;
        for(int i= 0; i < longest; i++)
        {
            texture.SetPixel(x, y, color);
            numerator += shortest;
            if (!(numerator < longest))
            {
                numerator -= longest;
                x += dx1;
                y += dy1;
            }
            else
            {
                x += dx2;
                y += dy2;
            }
        }

    }
    public void ADDA(float x0, float y0, float x1, float y1, Color line)
    {
        if (x0 == x1)
        {
            if (y1 > y0)
            {
                for(int y = (int)y0;y>= y1; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
            else
            {
                for(int y=(int)y1; y<=y0; y++)
                {
                    texture.SetPixel((int)x0, y, line);
                }
            }
        }
        else
        {
            float Dx = (x1 - x0);
            float Dy = (y1 - y0);
            float m = (y1 - y0) / (x1 - x0);
            float k;
            if (Dx > Dy) { k = Dx; }
            else { k = Dy; }
            float y = y0;
            float x = x0;
            if (m <= 1)
            {
                for(int i = 0; i <= k; i++)
                {
                    y += m;
                    x += 1;
                    texture.SetPixel((int)x, (int)y, line);
                }
            }
            else
            {
                for(int i=0; i<= k; i++)
                {
                    x += (1 / m);
                    y += 1;
                    texture.SetPixel((int)x, (int)y, line);
                }
            }
        }
    }
    public void SaveTexture()
    {
        byte[] bytes = texture.EncodeToPNG();
        var dirPath = Application.dataPath + "/RenderOutput";
        if (!System.IO.Directory.Exists(dirPath))
        {
            System.IO.Directory.CreateDirectory(dirPath);
        }
        System.IO.File.WriteAllBytes(dirPath + "/R_" + Random.Range(0, 100000) + ".png", bytes);
        Debug.Log(bytes.Length / 1024 + "Kb was saved as: " + dirPath);
#if UNITY_EDITOR
    UnityEditor.AssetDatabase.Refresh();
#endif
    }
    
}
