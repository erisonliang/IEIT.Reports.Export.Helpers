# IEIT.Reports.Export.Helpers

��� ���������� �������� ����������� ���������� [DocumentFormat.OpenXml](https://www.nuget.org/packages/DocumentFormat.OpenXml/). 
� ������������� ��� ������������ ������� � ������� Microsoft Excel 2007 � ���� (.xlsx). �� ������������ ������ Microsoft Excel ���� ������ 2007 (����� �������.xls)
��� ���������� ������� ��� ����, ����� ��������� ������ � Excel ������� ��������� ������ DocumentFormat.OpenXml.

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