﻿using DocumentFormat.OpenXml.Packaging;
using IEIT.Reports.Export.Helpers.Spreadsheet;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using Usage.Interfaces;
using System.Reflection;
using System;
using System.Text.RegularExpressions;

namespace Usage
{
    
    static class Program
    {

        static uint styleRed;
        static uint styleBlue;
        static uint styleGreen;

        static RunProperties superscript;

        enum MyStyle
        {
            Style1,
            Style2,
            Style3,
            Style4
        }

        static void Main(string[] args)
        {
            Try2(args);
        }
        


        static void Try1(string[] args)
        {
            var filepath = ".././hello.xlsx";
            using (var doc =  Document.CreateWorkbook(filepath))
            {
                var ws = doc.GetWorksheets().First();
                //ws.AddShape();
                ws.Save();
                doc.WorkbookPart.Workbook.Save();
            }
        }

        static void Try2(string[] args)
        {
            var filepath = "Temp.xlsx";

            if (File.Exists(filepath))
            {
                File.Delete(filepath);
            }
            
            var doc = Document.CreateWorkbook(filepath);

            InitStyles(doc);

            var ws = doc.GetWorksheet("Sheet1");

            ws.Write("Example table").To("b2").WithStyle(styleGreen);
            ws.MergeCells("b2:D2");

            ws.Write("Row1").WithStyle(styleRed).To("B3");
            ws.Write("Value1").To("C3");
            ws.Write("Value2").To("D3");

            ws.Write("Row2").WithStyle(styleBlue).To("B4");
            ws.Write("Value3").To("C4");
            ws.Write("Value4").To("D4");


            var df = new DifferentialFormat(new NumberingFormat() { NumberFormatId = 164U, FormatCode = "#,##0.000" });
            ws.AddFormattingRule("MOD(A1, 1) <> 0", df);

            doc.SaveAndClose();

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
