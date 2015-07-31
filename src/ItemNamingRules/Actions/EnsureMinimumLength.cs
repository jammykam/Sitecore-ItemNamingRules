//-----------------------------------------------------------------------------------
// <copyright file="EnsureMinimumLength.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.EnsureMinimumLength type.
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
    /// Rules engine action to rename an item with characters from 
    /// <see cref="DefaultName" /> if the name does not meet or exceed
    /// the number of characters in that string.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class EnsureMinimumLength<T> : RuleAction<T> where T : RuleContext
    {
        /// <summary>
        /// Gets or sets the string from which to append characters 
        /// to item names that are not longer than this string.
        /// </summary>
        public string DefaultName
        {
            get;
            set;
        }

        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.Name.Length >= this.DefaultName.Length)
                return;

            ruleContext.Item.Name += this.DefaultName.Substring(ruleContext.Item.Name.Length - 1);
        }
    }
}