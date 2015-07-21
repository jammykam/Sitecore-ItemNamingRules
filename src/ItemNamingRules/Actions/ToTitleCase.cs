//-----------------------------------------------------------------------------------
// <copyright file="Lowercase.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.Lowercase type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

using Sitecore.Rules;
using Sitecore.Rules.Actions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{

    /// <summary>
    /// Rules engine action to lowercase item names.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class ToTitleCase<T> : RuleAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            ruleContext.Item.Name = TitleCase(ruleContext.Item.Name);
        }

        private string TitleCase(string word)
        {
            string newWord = System.Text.RegularExpressions.Regex.Replace(word, "([a-z](?=[A-Z])|[A-Z](?=[A-Z][a-z]))", "$1+");
            newWord = System.Globalization.CultureInfo.InvariantCulture.TextInfo.ToTitleCase(newWord);
            newWord = newWord.Replace("+", "");
            return newWord;
        }
    }
}
