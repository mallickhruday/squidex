﻿// ==========================================================================
//  Squidex Headless CMS
// ==========================================================================
//  Copyright (c) Squidex UG (haftungsbeschränkt)
//  All rights reserved. Licensed under the MIT license.
// ==========================================================================

using Squidex.Infrastructure;
using System.Collections.ObjectModel;

namespace Squidex.Domain.Apps.Core.Rules.Triggers
{
    [TypeName(nameof(ContentChangedTriggerV2))]
    public sealed class ContentChangedTriggerV2 : RuleTrigger
    {
        public const string Name = "ContentChanged";

        public ReadOnlyCollection<ContentChangedTriggerSchemaV2> Schemas { get; set; }

        public bool HandleAll { get; set; }

        public override T Accept<T>(IRuleTriggerVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }

        public override void Freeze()
        {
            base.Freeze();

            if (Schemas != null)
            {
                foreach (var schema in Schemas)
                {
                    schema.Freeze();
                }
            }
        }
    }
}
