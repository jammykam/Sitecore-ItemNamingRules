//-----------------------------------------------------------------------------------
// <copyright file="EnsureMaximumLength.cs" company="Sitecore Shared Source">
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
    /// Rules engine action to ensure item name does not exceed  <see cref="MaxLength" /> 
    /// otherwise trim string.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class EnsureMaximumLength<T> : RuleAction<T> where T : RuleContext
    {
        /// <summary>
        /// Gets or sets the maximum allowed length for item names.
        /// </summary>
        public int MaxLength
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
            if (this.MaxLength > 0 && ruleContext.Item.Name.Length > this.MaxLength)
            {
                ruleContext.Item.Name = ruleContext.Item.Name.Substring(0, this.MaxLength);
            }
        }
    }
}