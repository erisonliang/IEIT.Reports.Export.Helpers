﻿using DocumentFormat.OpenXml.Packaging;
using IEIT.Reports.Export.Helpers.Spreadsheet;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Usage
{
    
    static class Program
    {

        static uint styleRed;
        static uint styleBlue;
        static uint styleGreen;

        static RunProperties superscript;

        static void Main(string[] args)
        {
            var filepath = "Temp.xlsx";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }



            var doc = SpreadsheetHelper.CreateBlank(filepath);

            InitStyles(doc);

            var ws = doc.GetWorksheet("Sheet1");

            ws.Write("Example table").To("B2").WithStyle(styleGreen);
            ws.MergeCells("B2:D2");

            ws.Write("Row1").WithStyle(styleRed).To("B3");
            ws.Write("Value1").To("C3");
            ws.Write("Value2").To("D3");

            ws.Write("Row2").WithStyle(styleBlue).To("B4");
            ws.Write("Value3").To("C4");
            ws.Write("Value4").To("D4");


            var df = new DifferentialFormat( new NumberingFormat() { NumberFormatId = 164U, FormatCode = "#,##0.000" } );
            ws.AddFormattingRule("MOD(A1, 1) <> 0", df);

            doc.Save();
            doc.Close();

        }
        
        static void InitStyles(SpreadsheetDocument doc)
        {

            superscript = new RunProperties(
                new VerticalTextAlignment() { Val = VerticalAlignmentRunValues.Superscript }
                , new FontSize() { Val = 11.0 }
                );

            var stylesheet = doc.GetStylesheet();

            styleRed = stylesheet.MakeCellStyle().WithFill("FF9090").Build();
            
            var titleFont = new Font()
            {
                FontSize = new FontSize() { Val = 18U },
                Bold = new Bold() { Val = true }
            };

            styleGreen = stylesheet.MakeCellStyle().WithFill("90FF90").WithFont(titleFont).Build();
            
            styleBlue = stylesheet.MakeCellStyle().WithFill("9090FF").Build();

        }
        

    }


}
