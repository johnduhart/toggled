Toggled
=======
Feature toggles for .NET

[![NPM Version](https://img.shields.io/nuget/v/Toggled.svg)](https://www.nuget.org/packages/Toggled/) [![MyGet Pre Release](https://img.shields.io/myget/johnduhart-nuget-ci/vpre/Toggled.svg?maxAge=2592000)]()

|Branch|AppVeyor|CodeCov|
|------|:--------:|:------:|
|master|[![Master Build status](https://ci.appveyor.com/api/projects/status/sgd8juq9pitr2o8l/branch/master?svg=true)](https://ci.appveyor.com/project/johnduhart/toggled/branch/master)|[![codecov](https://codecov.io/gh/johnduhart/toggled/branch/master/graph/badge.svg)](https://codecov.io/gh/johnduhart/toggled)|
|develop |[![Build status](https://ci.appveyor.com/api/projects/status/sgd8juq9pitr2o8l/branch/develop?svg=true)](https://ci.appveyor.com/project/johnduhart/toggled/branch/master)|[![codecov](https://codecov.io/gh/johnduhart/toggled/branch/develop/graph/badge.svg)](https://codecov.io/gh/johnduhart/toggled)|

## Usage
Create and set your context:

```csharp
Feature.Context = new FeatureContext(new FeatureToggleProvider(
	new AppSettingsToggle(),
	new DefaultValueToggle()));
```

Create a new feature:

```csharp
IFeature MyFeature = FeatureBuilder.Create("MyFeature")
						.Description("This is my feature.")
						.WithDefaultValue(false)
						.Build();
```

And then check to see if it's enabled.

```csharp
if (Feature.IsEnabled(MyFeature))
{
	// Feature code here
}
```