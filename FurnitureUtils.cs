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
        public static List<FamilyType> GetFurnitureType(ExternalCommandData commandData)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            List<FamilyType> familyType = new FilteredElementCollector(doc)
                                                        .OfClass(typeof(FamilyType))
                                                        .OfCategory(BuiltInCategory.OST_Furniture)
                                                        .Cast<FamilyType>()
                                                        .ToList();
            return familyType;
        }
    }
}
