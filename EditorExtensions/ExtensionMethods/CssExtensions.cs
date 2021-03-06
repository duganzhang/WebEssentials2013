﻿using System;
using Microsoft.CSS.Core;
using Microsoft.CSS.Editor.Schemas;

namespace MadsKristensen.EditorExtensions
{
    public static class CssExtensions
    {
        ///<summary>Gets the selector portion of the text of a Selector object, excluding any trailing comma.</summary>
        public static string SelectorText(this Selector selector)
        {
            if (selector.Comma == null) return selector.Text;
            return selector.Text.Substring(0, selector.Comma.Start - selector.Start).Trim();
        }

        public static bool IsPseudoElement(this ParseItem item)
        {
            if (item.Text.StartsWith("::", StringComparison.Ordinal))
                return true;

            var schema = CssSchemaManager.SchemaManager.GetSchemaRoot(null);
            return schema.GetPseudo(":" + item.Text) != null;
        }
    }
}
