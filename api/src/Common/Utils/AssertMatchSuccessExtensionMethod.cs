using System;
using System.Text.RegularExpressions;
using Suckless.Asserts;

namespace Common.Utils
{
    public static class AssertMatchSuccessExtensionMethod
    {
        public static ref readonly Metadata<Match>  Success(in this Metadata<Match> metadata)
        {
            if (!metadata.Value.Success) throw new ApplicationException($"Matching value must be succeed.");

            return ref metadata;
        }
    }
}
