//-----------------------------------------------------------------------------------
// <copyright file="HasLayoutDetailsForDefaultDevice.cs" company="Sitecore Shared Source">
// Copyright (c) Sitecore.  All rights reserved.
// </copyright>
// <summary>
// Defines the 
// Sitecore.Sharedsource.Rules.Actions.Conditions.HasLayoutDetailsForDefaultDevice 
// type.
// </summary>
// <license>
// http://sdn.sitecore.net/Resources/Shared%20Source/Shared%20Source%20License.aspx
// </license>
// <url>http://marketplace.sitecore.net/en/Modules/Item_Naming_rules.aspx</url>
//-----------------------------------------------------------------------------------

using Sitecore.Rules;
using Sitecore.Rules.Conditions;

namespace Sitecore.Sharedsource.ItemNamingRules.Conditions
{
    /// <summary>
    /// Rules engine condition to determine if an item has 
    /// layout details for the default device.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class HasLayoutDetailsForDefaultDevice<T> : OperatorCondition<T>
      where T : RuleContext
    {
        /// <summary>
        /// Condition implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        /// <returns>True if the item has layout details for the default device, 
        /// otherwise False.</returns>
        protected override bool Execute(T ruleContext)
        {
            foreach (Sitecore.Data.Items.DeviceItem compare
              in ruleContext.Item.Database.Resources.Devices.GetAll())
            {
                if (compare.IsDefault)
                {
                    return ruleContext.Item.Visualization.GetLayout(compare) != null;
                }
            }

            return false;
        }
    }
}
