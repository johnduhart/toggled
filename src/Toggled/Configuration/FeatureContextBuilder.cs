using System;
using System.Collections.Generic;

namespace Toggled.Configuration
{
    public class FeatureContextBuilder
    {
        private readonly List<IFeatureToggler> _togglers = new List<IFeatureToggler>();

        public ITogglerBuilder Togglers => new TogglerBuilder(this);

        public FeatureContextBuilder WithTogglers(params IFeatureToggler[] togglers)
        {
            _togglers.AddRange(togglers);
            return this;
        }

        public FeatureContextBuilder WithTogglers(IEnumerable<IFeatureToggler> togglers)
        {
            _togglers.AddRange(togglers);
            return this;
        }

        public FeatureContextBuilder WithToggler(IFeatureToggler toggler)
        {
            _togglers.Add(toggler);
            return this;
        }

        public IFeatureContext GetContext()
        {
            return new FeatureContext(new FeatureTogglerSource(_togglers.ToArray()));
        }

        private class TogglerBuilder : ITogglerBuilder
        {
            private readonly FeatureContextBuilder _featureContextBuilder;
            private readonly List<IFeatureToggler> _togglers = new List<IFeatureToggler>();

            public TogglerBuilder(FeatureContextBuilder featureContextBuilder)
            {
                _featureContextBuilder = featureContextBuilder;
            }

            public ITogglerBuilder AddToggler(IFeatureToggler featureToggler)
            {
                _togglers.Add(featureToggler);
                return this;
            }

            public FeatureContextBuilder End()
            {
                _featureContextBuilder.WithTogglers(_togglers);
                return _featureContextBuilder;
            }
        }
    }
}