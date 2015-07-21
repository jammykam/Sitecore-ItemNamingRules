//-----------------------------------------------------------------------------------
// <copyright file="SaveNameChanges.cs" company="Sitecore Shared Source">
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

using System;
using Sitecore.Data.Items;
using Sitecore.Rules;
using Sitecore.Rules.Actions;

namespace Sitecore.Sharedsource.ItemNamingRules.Actions
{
    /// <summary>
    /// Rules engine action to save item changes.
    /// </summary>
    /// <typeparam name="T">Type providing rule context.</typeparam>
    public class SaveNameChanges<T> : RuleAction<T> where T : RuleContext
    {
        /// <summary>
        /// Action implementation.
        /// </summary>
        /// <param name="ruleContext">The rule context.</param>
        public override void Apply(T ruleContext)
        {
            if (ruleContext.Item.Name != ruleContext.Item.InnerData.Definition.Name)
            {
                ApplyRule(ruleContext.Item);
            }
        }

        private void ApplyRule(Item item)
        {
            if (item.Template.StandardValues != null && item.ID == item.Template.StandardValues.ID)
            {
                return;
            }

            // ignore site home items, otherwise the config will not match!
            foreach (Sitecore.Web.SiteInfo site in Sitecore.Configuration.Factory.GetSiteInfoList())
            {
                if (String.Compare(site.RootPath + site.StartItem, item.Paths.FullPath, true) == 0)
                {
                    return;
                }
            }

            using (new Sitecore.Data.Items.EditContext(item, Sitecore.SecurityModel.SecurityCheck.Disable))
            {
                // modifications have been made to the item already
                // this call will commit those changes
            }
        }
    }

}