﻿using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingLibrary
{
    public class FamilySymbolUtils
    {
        public static List<FamilySymbol> GetFamilySymbols(ExternalCommandData commandData)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;

            var familySymbols = new FilteredElementCollector(doc)
                .OfClass(typeof(FamilySymbol))
                .Cast<FamilySymbol>()
                .ToList();

            return familySymbols;
        }

        public static List<FamilySymbol> GetFamilySymbolsTitleBlock(ExternalCommandData commandData)
        {
            var uiapp = commandData.Application;
            var uidoc = uiapp.ActiveUIDocument;
            var doc = uidoc.Document;

            List<FamilySymbol> titleBlock = new FilteredElementCollector(doc)
                                        .OfClass(typeof(FamilySymbol))
                                        .OfCategory(BuiltInCategory.OST_TitleBlocks)
                                        .Cast<FamilySymbol>()
                                        .ToList();


            return titleBlock;
        }
    }
}
