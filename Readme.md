# IEIT.Reports.Export.Helpers

Read [english version](ReadmeEng.md)


��� ���������� �������� ����������� ���������� [DocumentFormat.OpenXml](https://www.nuget.org/packages/DocumentFormat.OpenXml/). 
� ������������� ��� ������������ ������� � ������� Microsoft Excel 2007 � ���� (.xlsx). �� ������������ ������ Microsoft Excel ���� ������ 2007 (����� �������.xls)
��� ���������� ������� ��� ����, ����� ��������� ������ � Excel ������� ��������� ������ DocumentFormat.OpenXml.

## ��������� � ������� NuGet
```
PM> Install-Package IEIT.Reports.Export.Helpers
```

## ����� ��� ���?
� ������ ����������� �� ��������� �������� � ��������� DocumentFormat.OpenXml. ��������� ������ �������� ���� ����������� ��� ������������ �������.
��������, ��� ���� ����� ������� ��������:
```C#
var filePath = "myFolder/excelFile.xlsx";
var editable = true;
var excelDoc = SpreadsheetDocument.Open(filePath, editable);
```
��� ������, ��� �� ���������� DocumentFormat.OpenXml, � ������ ������. 

� ������ ������������ �������� ���������� �����.

������ � ����:
```C#
var worksheet = excelDoc.GetWorksheet("���� 1");
worksheet.Write("������ ���!").To("B2");
excelDoc.SaveAndClose();
```

��������� � ������������ ������:
```C#
var existingStyleIndex = worksheet.GetCell("A1").StyleIndex;
var cell = worksheet.MakeCell("A4");
cell.StyleIndex = existingStyleIndex;
```

��� ����� ��������� ����� ��� ������ � ������:
```C#
worksheet.Write("������ ���!").To("B2").WithStyle(existingStyleIndex);
```

����������� �����:
```C#
worksheet.MergeCells("A2:B4");
```