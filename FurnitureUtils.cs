using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class FurnitureUtils
    {
        public static List<FamilySymbol> GetFurnitureType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilySymbol> familyType = new FilteredElementCollector(doc)
                                                        .OfCategory(BuiltInCategory.OST_Furniture)
                                                        .OfClass(typeof(FamilySymbol))
                                                        .Cast<FamilySymbol>()
                                                        .ToList();
            return familyType;
        }
    }
}
