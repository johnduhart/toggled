using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Toggled
{
    public class FeatureBuilder
    {
        private readonly string _featureId;
        private readonly List<IFeatureTrait> _traits = new List<IFeatureTrait>();
        private string _description;

        private FeatureBuilder(string featureId)
        {
            _featureId = featureId;
        }

        public static FeatureBuilder Create(string featureId)
        {
            if (featureId == null)
                throw new ArgumentNullException(nameof(featureId));

            return new FeatureBuilder(featureId);
        }

        public IFeature Build()
        {
            return new FeatureImpl
            {
                Id = _featureId,
                Description = _description,
                Traits = new ReadOnlyCollection<IFeatureTrait>(_traits)
            };
        }

        private class FeatureImpl : IFeature
        {
            public string Id { get; internal set; }
            public string Description { get; internal set; }
            public IEnumerable<IFeatureTrait> Traits { get; internal set; }
        }

        public FeatureBuilder Description(string description)
        {
            if (description == null)
                throw new ArgumentNullException(nameof(description));

            _description = description;
            return this;
        }

        public FeatureBuilder WithTrait(IFeatureTrait trait)
        {
            if (trait == null)
                throw new ArgumentNullException(nameof(trait));

            _traits.Add(trait);
            return this;
        }
    }
}