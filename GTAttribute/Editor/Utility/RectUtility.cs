using System.Collections.Generic;
using UnityEngine;

namespace GTUtility
{
    public static class RectUtility
    {

        public static Rect Chop(Rect rect,float left,float right,float top,float bottom)
        {
            Rect output = new Rect();

            output.xMin = rect.xMin + left;
            output.xMax = rect.xMax - right;
            output.yMin = rect.yMin + bottom;
            output.yMax = rect.yMax - top;

            return output;
        }

        public static Rect Chop(Rect rect,float amount)
        {
            return Chop(rect, amount, amount, amount, amount);
        }

        public static Rect Chop(Rect rect,float horizontal,float vertical)
        {
            return Chop(rect, horizontal, horizontal, vertical, vertical);
        }

        public static Rect[][] Split(Rect rect, int horizontalSplite, int verticaleSplite, float horizontalSpecing, float verticalSpacing)
        {
            Rect[][] output = new Rect[verticaleSplite][];
            Rect[] tmp = SplitVertical(rect,verticaleSplite, verticalSpacing);

            for (int i = 0; i < verticaleSplite; i++)
            {
                output[i] = SplitHorizontal(tmp[i], horizontalSplite, horizontalSpecing);
            }

            return output;
        }

        public static Rect[] SplitHorizontal(Rect rect, int splite, float spacing)
        {
            Rect[] output = new Rect[splite];

            float rectWidth = rect.width / splite;
            rectWidth -= spacing;
            rectWidth += spacing / splite;
            float xPosition = rect.x;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new Rect(xPosition, rect.y, rectWidth, rect.height);
                xPosition = output[i].xMax + spacing;
            }

            return output;
        }

        public static Rect[] SplitHorizontal(Rect rect, int splite, float spacing,params float[] sizes)
        {
            Rect[] output = new Rect[splite];

            float rectWidth = rect.width / splite;
            rectWidth -= spacing;
            rectWidth += spacing / splite;
            float xPosition = rect.x;

            

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new Rect();
                output[i].xMin = xPosition;
                output[i].xMax = sizes[0] * rectWidth;
                output[i].height = rect.height;
                xPosition = output[i].xMax + spacing;
            }

            return output;
        }

        public static Rect[] SplitVertical(Rect rect, int splite, float spacing)
        {
            Rect[] output = new Rect[splite];

            float rectHeight = rect.height / splite;
            rectHeight -= spacing;
            rectHeight += spacing / splite;
            float yPosition = rect.y;
            for (int i = 0; i < output.Length; i++)
            {
                output[i] = new Rect(rect.x, yPosition, rect.width, rectHeight);
                yPosition = output[i].yMax + spacing;
            }

            return output;
        }

        public static Rect SliceVertical(Rect rect, float height, out Rect slice)
        {
            Rect output = rect;
            slice = new Rect();

            if (height < rect.height)
            {
                output.size = new Vector2(rect.width, height);
                slice.position = new Vector2(rect.x, rect.y + height);
                slice.size = new Vector2(rect.width, rect.height - height);
            }

            return output;
        }

        public static Rect SliceVertical(Rect rect, float height, bool firstPart = true)
        {
            Rect output = rect;

            if (height < rect.height)
            {
                if (firstPart)
                {
                    output.size = new Vector2(rect.width, height);
                }
                else
                {
                    output.position = new Vector2(rect.x, rect.y + height);
                    output.size = new Vector2(rect.width, rect.height - height);
                }
            }

            return output;
        }

        public static Rect SliceHoriozntal(Rect rect, float width, out Rect slice)
        {
            Rect output = rect;
            slice = new Rect();

            if (width < rect.width)
            {
                output.size = new Vector2(width, rect.height);
                slice.position = new Vector2(rect.x + width, rect.y);
                slice.size = new Vector2(rect.width - width, rect.height);
            }

            return output;
        }

        public static Rect SliceHoriozntal(Rect rect, float width, bool firstPart = true)
        {
            Rect output = rect;

            if (width < rect.width)
            {
                if (firstPart)
                {
                    output.size = new Vector2(width, rect.height);
                }
                else
                {
                    output.position = new Vector2(rect.x + width, rect.y);
                    output.size = new Vector2(rect.width - width, rect.height);
                }
            }

            return output;
        }
    }
}