# dotnetCampus.Autofac.Annotation

| Build | NuGet |
|--|--|
|![](https://github.com/dotnet-campus/dotnetCampus.Autofac.Annotation/workflows/.NET%20Core/badge.svg)|[![](https://img.shields.io/nuget/v/dotnetCampus.Autofac.Annotation.svg)](https://www.nuget.org/packages/dotnetCampus.Autofac.Annotation)|

项目灵感来源于：
[yuzd/Autofac.Annotation: Autofac extras library for component registration via attributes 用注解来load autofac 摆脱代码或者xml配置和java的spring的注解注入一样的体验](https://github.com/yuzd/Autofac.Annotation )

`yuzd/Autofac.Annotation` 这个项目的功能要丰富更多。

> 在实际使用时，发现`yuzd/Autofac.Annotation`有时属性注入会失败。（非必现）没有仔细调查原因，可能是哪里用得不对。
> 为了避免在实际项目中出现非预期的问题，就实现了一个简单版本的，通过 Attribute 完成自动注册的库。

## 1 Autofac 扩展

### 1.1 通过 Atttibute 实现服务的注册

| Attribute           | 作用                                                   |
|---------------------|------------------------------------------------------|
| ComponentAttribute  | 标记在 class 上，将 class 作为组件注册到容器中          |
| RepositoryAttribute | 与 ComponentAttribute 相同，默认作用域为 SingleInstance |
| ServiceAttribute    | 与 ComponentAttribute 相同，默认作用域为 SingleInstance |

### 1.2 通过 AutowiredAttribute 进行属性注册

默认情况下，仅对使用了 `ComponentAttribute`（Repository，Service）标记的类中，对属性标记 `AutowiredAttribute` 才有效。

### 1.3 IComponentDetector

`IComponentDetector` 是作为 `ComponentAttribute` 的补充，可以批量注册一类组件。

对于已经通过其它方式注册，仅仅是想通过 `AutowiredAttribute` 进行属性注入的，可以在返回的 `ComponentModel` 中，将 `IsOnlyRegisterProperties` 标记为 `true`(这个是默认值)。

## 2 Quick Start

``` bash
Install-Package dotnetCampus.Autofac.Annotation -Version 0.0.1-alpha
```

``` csharp
// autofac 的 RegisterModule
// SetComponentDetector 非必须
builder.RegisterModule(
                new AutofacAnnotationModule(_assemblies)
                    .SetComponentDetector(new AutofacComponentDetector()));
```

---
