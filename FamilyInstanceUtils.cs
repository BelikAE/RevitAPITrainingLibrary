using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;


namespace RevitAPITrainingLibrary
{
    public class FamilyInstanceUtils
    {
        public static FamilyInstance CreateFamilyInstance(
            ExternalCommandData commandData,
            FamilySymbol oFamSymb,
            XYZ insertionPoint,
            Level oLevel)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uidoc.Document;
            FamilyInstance familyInstance = null;
            //create family instance
            using (var t = new Autodesk.Revit.DB.Transaction(doc, "Create family instance"))
            {
                t.Start();
                if (!oFamSymb.IsActive)
                {
                    oFamSymb.Activate();
                    doc.Regenerate();
                }
                familyInstance = doc.Create.NewFamilyInstance(
                                    insertionPoint,
                                    oFamSymb,
                                    oLevel,
                                    Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                t.Commit();
            }
            return familyInstance;
        }



        public static void CreateElementsAlongLine(Document doc, XYZ start, XYZ end, FamilySymbol symbol, int count)
        {
            using (var ts = new Transaction(doc, "Transaction"))
            {
                ts.Start();
                var line = Line.CreateBound(start, end);
                for (int i = 1; i <= count; i++)
                {
                    double param = (double)i / (count + 1);
                    var position = line.Evaluate(param, true);
                    doc.Create.NewFamilyInstance(position, symbol, StructuralType.NonStructural);
                }
                ts.Commit();
            }
        }
    }
}
