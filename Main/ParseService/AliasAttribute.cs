using System;

namespace Main.ParseService
{
    /// <summary>
    /// Атрибут псевдонима
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
    public class AliasAttribute : Attribute
    {
        public string Alias { get; }

        public AliasAttribute(string alias)
        {
            Alias = alias;
        }
    }
}