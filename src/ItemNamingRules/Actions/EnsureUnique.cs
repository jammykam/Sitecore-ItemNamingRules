//-----------------------------------------------------------------------------------
// <copyright file="EnsureUnique.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the Sitecore.Sharedsource.Rules.Actions.EnsureUnique type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Rules.Actions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{

    /// <summary>
    /// Rules engine action to ensure unique item names under a parent
    /// by replacing trailing characters with number sequence.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class EnsureUnique<T> : RuleAction<T> where T : RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            int sequence = 1;
            string itemName = ruleContext.Item.Name;
            List<Item> siblings = ruleContext.Item.Parent.GetChildren().Where(c => c.ID != ruleContext.Item.ID).ToList();

            while (siblings.Any(s => s.Name == itemName))
            {
                itemName = String.Format("{0}-{1}", ruleContext.Item.Name, sequence++);
            }

            ruleContext.Item.Name = itemName;
        }
    }
}
