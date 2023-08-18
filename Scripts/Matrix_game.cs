using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix_game : LayoutGroup
{
    public int rows;
    public int colms;

    public Vector2 cellSize;
    public Vector2 cellSpacing;
    //public Vector2 padding_horizontal;
    //public Vector2 padding_vertical;


    public override void CalculateLayoutInputVertical()
    { 
        float parentWidth = rectTransform.rect.width;
        float parentHeight = rectTransform.rect.height;

        float cellWidth = (parentWidth - padding.left - padding.right - (colms - 1) * cellSpacing.x) / (float)colms;
        float cellHeight = (parentHeight - padding.top - padding.bottom - (rows - 1)*cellSpacing.y) / (float)rows;

        cellSize.x = cellWidth;
        cellSize.y = cellHeight;

        int columCount = 0;
        int rowsCount = 0;

        for(int i = 0; i < rectTransform.childCount; i++)
        {
            rowsCount = i / colms;
            columCount = i% colms;

            var child = rectChildren[i];

            var xPos = columCount * cellSize.x + padding.left + cellSpacing.x * columCount;
            var yPos = rowsCount * cellSize.y + padding.top + cellSpacing.y * rowsCount;

            SetChildAlongAxis(child, 0, xPos, cellSize.x);
            SetChildAlongAxis(child, 1, yPos, cellSize.y);

        }
    }

    public override void SetLayoutHorizontal()
    {
      //implemented
    }

    public override void SetLayoutVertical()
    {
      
    }
}
