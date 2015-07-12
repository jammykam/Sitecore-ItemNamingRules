//-----------------------------------------------------------------------------------
// <copyright file="RenamingAction.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.RenamingAction type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

using System;
using Sitecore.Rules;
using Sitecore.Rules.Actions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{

    /// <summary>
    /// Base class for rules engine actions that checks if item name has changed
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public abstract class RenamingAction<T> : RuleAction<T>
      where T : RuleContext
    {
        /// <summary>
        /// Check if Item Name has changed from user input
        /// </summary>
        protected void CheckItemNameChanged(T ruleContext)
        {
            if (ruleContext.Item.Name == ruleContext.Item.InnerData.Definition.Name)
            {
                ruleContext.Abort();
            }
        }
    }
}
