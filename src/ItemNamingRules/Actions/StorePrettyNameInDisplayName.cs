//-----------------------------------------------------------------------------------
// <copyright file="StorePrettyNameInDisplayName.cs" company="Sitecore Shared Source">
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
    /// Rules engine action to save user input to display name.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class StorePrettyNameInDisplayName<T> : RuleAction<T> where T : RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            ruleContext.Item.Appearance.DisplayName = ruleContext.Item.Name;
        }
    }
}