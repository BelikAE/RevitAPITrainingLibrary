using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class SheetUtils
    {
        public  static void CreateSheets(ExternalCommandData commandData, FamilySymbol titleBlock, int count, List<View> viewToPlace, string designedBy)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;
            List<ViewSheet> sheets = new List<ViewSheet>();
            using (Transaction t = new Transaction(doc, "Create Sheets"))
            {
                t.Start();
                for (int i = 0; i < count; i++)
                {
                    ViewSheet sheet = ViewSheet.Create(doc, titleBlock.Id);
                    sheets.Add(sheet);
                    if (viewToPlace != null)
                    {
                        UV location = new UV((sheet.Outline.Max.U - sheet.Outline.Min.U) / 2,
                                           (sheet.Outline.Max.V - sheet.Outline.Min.V) / 2);
                        foreach (View view in viewToPlace)
                        {
                            Viewport.Create(doc, sheet.Id, view.Id, new XYZ(location.U, location.V, 0));
                        }
                    }
                }
                t.Commit();
            }

            using (Transaction t = new Transaction(doc, "Sheets"))
            {
                t.Start();
                foreach(ViewSheet sheet in sheets)
                {
                    sheet.get_Parameter(BuiltInParameter.SHEET_DESIGNED_BY).Set(designedBy);
                }

                t.Commit();
            }
        }
    }
}

