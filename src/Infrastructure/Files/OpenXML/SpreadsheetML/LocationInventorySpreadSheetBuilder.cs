using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using PropertyCore.Application.Common.Interfaces;
using PropertyCore.Application.Property.Queries.GetLocationInventoryFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PropertyCore.Infrastructure.Files.OpenXML.SpreadsheetML
{
    public class LocationInventorySpreadSheetBuilder : ILocationInventorySpreadsheetBuilder
    {
        private int _itemsSheetId = 1;
        private int _titleSheetId = 0;
        public byte[] Generate(LocationInventoryResults results)
        {
            var mem = new MemoryStream();
            byte[] byteArray = File.ReadAllBytes("..\\Infrastructure\\Files\\OpenXML\\SpreadsheetML\\Templates\\InventoryListTemplate.xlsx");
            mem.Write(byteArray, 0, byteArray.Length);
            using (SpreadsheetDocument spreadSheet = SpreadsheetDocument.Open(mem, true))
            {
                // Get the SharedStringTablePart. If it does not exist, create a new one.
                SharedStringTablePart shareStringPart;
                if (spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().Count() > 0)
                {
                    shareStringPart = spreadSheet.WorkbookPart.GetPartsOfType<SharedStringTablePart>().First();
                }
                else
                {
                    shareStringPart = spreadSheet.WorkbookPart.AddNewPart<SharedStringTablePart>();
                }
                WorkbookPart wbPart = spreadSheet.WorkbookPart;

                // Title Sheet
                Sheet titleSheet = wbPart.Workbook.Descendants<Sheet>().ElementAt(_titleSheetId);
                WorksheetPart titleWorksheetPart = (WorksheetPart)(wbPart.GetPartById(titleSheet.Id));

                int timeIndex = InsertSharedStringItem(DateTime.Now.ToString("dddd, MMMM d, yyyy h:mm tt"), shareStringPart);
                Cell auditDateTimeCell = titleWorksheetPart.Worksheet.Descendants<Cell>().Where(x => x.CellReference == "C6").FirstOrDefault();
                auditDateTimeCell.CellValue = new CellValue(timeIndex.ToString());
                auditDateTimeCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);

                int locationIndex = InsertSharedStringItem($"{results.Location.Type} - {results.Location.Name}", shareStringPart);
                Cell locationNameCell = titleWorksheetPart.Worksheet.Descendants<Cell>().Where(x => x.CellReference == "C5").FirstOrDefault();
                if (locationNameCell != null)
                {
                    locationNameCell.CellValue = new CellValue(locationIndex.ToString());
                    locationNameCell.DataType = new EnumValue<CellValues>(CellValues.SharedString);
                }

                Cell totalItemsCell = titleWorksheetPart.Worksheet.Descendants<Cell>().Where(x => x.CellReference == "C7").FirstOrDefault();
                if (totalItemsCell != null)
                {
                    totalItemsCell.CellValue = new CellValue(results.Items.Count.ToString());
                    totalItemsCell.DataType = new EnumValue<CellValues>(CellValues.Number);
                }
                titleWorksheetPart.Worksheet.Save();

                // Items list
                Sheet itemsSheet = wbPart.Workbook.Descendants<Sheet>().ElementAt(_itemsSheetId);
                WorksheetPart itemsWorksheetPart = (WorksheetPart)wbPart.GetPartById(itemsSheet.Id);
                Worksheet workSheet1 = itemsWorksheetPart.Worksheet;
                SheetData sheetData1 = workSheet1.GetFirstChild<SheetData>();
                WriteValuesToRow(sheetData1, results.Items.OrderBy(x => x.BarCode).ToList());
                

                TableDefinitionPart tbl1 = itemsWorksheetPart.TableDefinitionParts.First();
                tbl1.Table.Reference.Value = $"A1:I{results.Items.Count + 1}";
                itemsWorksheetPart.Worksheet.Save();
            }
            mem.Seek(0, SeekOrigin.Begin);
            return mem.ToArray();
        }
        private void WriteValuesToRow(SheetData sheetData, List<LocationInventoryFilePropertyItemDto> items)
        {
            bool isFirstRow = true;
            foreach (var item in items)
            {
                if (isFirstRow)
                {
                    Row firstRow = sheetData.Descendants<Row>().ElementAt(1);
                    Cell cell1 = firstRow.Descendants<Cell>().ElementAt(0);
                    cell1.CellValue = new CellValue(item.BarCode);
                    cell1.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell2 = firstRow.Descendants<Cell>().ElementAt(1);
                    cell2.CellValue = new CellValue(item.CaseNumber);
                    cell2.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell3 = firstRow.Descendants<Cell>().ElementAt(2);
                    cell3.CellValue = new CellValue(item.PropertySheetNumber);
                    cell3.DataType = new EnumValue<CellValues>(CellValues.Number);

                    Cell cell4 = firstRow.Descendants<Cell>().ElementAt(3);
                    cell4.CellValue = new CellValue(item.CurrentLocation);
                    cell4.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell5 = firstRow.Descendants<Cell>().ElementAt(4);
                    cell5.CellValue = new CellValue(item.CurrentDisposition);
                    cell5.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell6 = firstRow.Descendants<Cell>().ElementAt(5);
                    cell6.CellValue = new CellValue(item.PropertyType);
                    cell6.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell7 = firstRow.Descendants<Cell>().ElementAt(6);
                    cell7.CellValue = new CellValue(item.ItemQuantity);
                    cell7.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell8 = firstRow.Descendants<Cell>().ElementAt(7);
                    cell8.CellValue = new CellValue(item.HoldStatus);
                    cell8.DataType = new EnumValue<CellValues>(CellValues.String);

                    Cell cell9 = firstRow.Descendants<Cell>().ElementAt(8);
                    cell9.CellValue = new CellValue(item.Description);
                    cell9.DataType = new EnumValue<CellValues>(CellValues.String);

                    isFirstRow = false;
                }
                else
                {
                    Row toAdd = new Row();
                    Cell cell1 = new Cell();
                    cell1.CellValue = new CellValue(item.BarCode);
                    cell1.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell1.StyleIndex = 1U;
                    toAdd.AppendChild(cell1);

                    Cell cell2 = new Cell();
                    cell2.CellValue = new CellValue(item.CaseNumber);
                    cell2.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell2.StyleIndex = 1U;
                    toAdd.AppendChild(cell2);

                    Cell cell3 = new Cell();
                    cell3.CellValue = new CellValue(item.PropertySheetNumber);
                    cell3.DataType = new EnumValue<CellValues>(CellValues.Number);
                    cell3.StyleIndex = 1U;
                    toAdd.AppendChild(cell3);

                    Cell cell4 = new Cell();
                    cell4.CellValue = new CellValue(item.CurrentLocation);
                    cell4.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell4.StyleIndex = 1U;
                    toAdd.AppendChild(cell4);

                    Cell cell5 = new Cell();
                    cell5.CellValue = new CellValue(item.CurrentDisposition);
                    cell5.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell5.StyleIndex = 1U;
                    toAdd.AppendChild(cell5);

                    Cell cell6 = new Cell();
                    cell6.CellValue = new CellValue(item.PropertyType);
                    cell6.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell6.StyleIndex = 1U;
                    toAdd.AppendChild(cell6);

                    Cell cell7 = new Cell();
                    cell7.CellValue = new CellValue(item.ItemQuantity);
                    cell7.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell7.StyleIndex = 1U;
                    toAdd.AppendChild(cell7);

                    Cell cell8 = new Cell();
                    cell8.CellValue = new CellValue(item.HoldStatus);
                    cell8.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell8.StyleIndex = 1U;
                    toAdd.AppendChild(cell8);

                    Cell cell9 = new Cell();
                    cell9.CellValue = new CellValue(item.Description);
                    cell9.DataType = new EnumValue<CellValues>(CellValues.String);
                    cell9.StyleIndex = 1U;
                    toAdd.AppendChild(cell9);
                    sheetData.AppendChild(toAdd);
                }
            }
        }
        // Given text and a SharedStringTablePart, creates a SharedStringItem with the specified text 
        // and inserts it into the SharedStringTablePart. If the item already exists, returns its index.
        private static int InsertSharedStringItem(string text, SharedStringTablePart shareStringPart)
        {
            // If the part does not contain a SharedStringTable, create one.
            if (shareStringPart.SharedStringTable == null)
            {
                shareStringPart.SharedStringTable = new SharedStringTable();
            }

            int i = 0;

            // Iterate through all the items in the SharedStringTable. If the text already exists, return its index.
            foreach (SharedStringItem item in shareStringPart.SharedStringTable.Elements<SharedStringItem>())
            {
                if (item.InnerText == text)
                {
                    return i;
                }

                i++;
            }

            // The text does not exist in the part. Create the SharedStringItem and return its index.
            shareStringPart.SharedStringTable.AppendChild(new SharedStringItem(new DocumentFormat.OpenXml.Spreadsheet.Text(text)));
            shareStringPart.SharedStringTable.Save();

            return i;
        }
    }
}
